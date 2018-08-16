using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidBody : MonoBehaviour {

	//references to player components
	private Rigidbody rb;
	private WindManager wm;

	//movement parameters
	public float vInput;
	public float hInput;
	public float speed = 10.0f;
	public float jumpHeight = 5.0f;

	//movement vectors
	public Vector3 forwardVector;

	//booleans to store object state
	public bool isJumping = false;
	public bool isBlowable = false;

	//get references to rotation and rigidbody components
	void Start () {
		rb = GetComponent<Rigidbody> ();
		wm = GameObject.Find ("Game Manager").GetComponent<WindManager> ();
	}

	void Update () {
		GetInput ();
		Turn ();
	}

	void FixedUpdate(){
		Run ();
	}

	//method to get inputs from the input manager
	void GetInput(){
		vInput = Input.GetAxis ("Vertical");
		hInput = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown("Jump") && isJumping == false){
			isJumping = true;
			Jump ();
		}
	}

	void Turn(){
		forwardVector = (new Vector3 (hInput, 0.0f, vInput)).normalized;
		transform.forward = forwardVector;
	}

	void Run(){
		rb.velocity = (transform.forward * speed * forwardVector.magnitude) + Physics.gravity;
	}

	void Jump(){
		Debug.Log ("JUMP");
		rb.AddForce (Vector3.up * (jumpHeight + Physics.gravity.magnitude));
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Platform") {
			isJumping = false;
		}
	}
}
