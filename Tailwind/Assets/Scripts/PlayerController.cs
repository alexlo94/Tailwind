using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerController.cs by Alexandros Lotsos
//Script to implement vector based controls for the main character in tailwind
//credit to Ryan Su for coming up with the trigger wind controls!
//Ryan Su: rls655@nyu.edu

public class PlayerController : MonoBehaviour {

	//container for the reference to the player's rigidbody and wind manager
	private Rigidbody rb;
	private WindManager wm;
	public Transform spawnPoint;

	//Input and Speed variables
	public float vInput;
	public float hInput;
	public float pSpeed;
	public float jFuel = 10.0f;

	//Direction and velocity vectors for the player
	public Vector3 pDir;
	public Vector3 pVel;

	//bool to keep track of jumping and jump height
	public bool isGrounded;
	public Vector3 lastPosition; //container for the players last position
	public float jHeight = 5.0f;

	//bool to keep track of wind status
	public bool isBlowable = false;

	public Transform camera;

	//start by getting a reference to the player's rigidbody and the game's wind manager
	//initializing the direction and velocity vectors
	void Start () {
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody> ();
		wm = GameObject.Find ("Game Manager").GetComponent<WindManager> ();

		pDir = new Vector3 (0.0f, 0.0f, 0.0f);
	}
	
	// use update to check player input
	void Update () {
		if (Input.GetButtonDown("Jump") && isGrounded){
			rb.AddForce (Vector3.up * jHeight);
		}
		if (Input.GetButton ("Fire1") && !isGrounded) { //TODO: Implement onColissionEnter/Exit with platforms scheme to check for grounded/jumping player state
			rb.drag = 8;
			isBlowable = true;

		} else {
			rb.drag = 0;
			isBlowable = false;
		}
	}

	//use fixed update to apply player input
	void FixedUpdate(){
		//get player input to construct velocity vector
		vInput = Input.GetAxis ("Vertical");
		hInput = Input.GetAxis ("Horizontal");
		//calculate player velocity
		pDir.x = hInput;
		pDir.z = vInput;
		pVel =  pDir*pSpeed;
		pVel = Vector3.ProjectOnPlane(camera.TransformVector (pVel), transform.up);
		transform.rotation = Quaternion.LookRotation (pVel);

		//apply player velocity and wind, if applicable
		if (isBlowable) {
			rb.MovePosition(rb.position + ((pVel + wm.CalcWind (gameObject.transform)) * Time.deltaTime));
		} else {
			rb.MovePosition(rb.position + (pVel*Time.deltaTime));
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Platform") {
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Platform") {
			isGrounded = false;
			lastPosition = this.gameObject.transform.position;
		}
	}

}
