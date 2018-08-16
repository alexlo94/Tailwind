using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCamera : MonoBehaviour {

	//get a reference to the target gameobject; the player
	public GameObject target;

	public Quaternion oRot;

	public float vCamInput;
	public float hCamInput;
	public float angleStep = 2;
	public float angleDiff; //calculates the difference between the player's Y-Axis and the camera's forward vector. Used to implement vertical rotation bounds

	// Use this for initialization
	void Start () {
		oRot = transform.rotation;

	}

	void FixedUpdate(){
		hCamInput = Input.GetAxis ("4th Axis");
		vCamInput = Input.GetAxis ("5th Axis");
		angleDiff = Vector3.Angle (target.transform.up, transform.forward);
	}
	// Update is called once per frame
	void Update () {
		//TODO: implement bounds onto camera rotations. See DS3 Camera
		if ((vCamInput >= 0.3f || vCamInput <= -0.3f)) {
			//rotate around the midpoint of the character
			gameObject.transform.RotateAround (target.transform.position, transform.right, angleStep * vCamInput);
		}
		if ((hCamInput >= 0.3f || hCamInput <= -0.3f)) {
			//rotate around the y-axis of the character
			gameObject.transform.RotateAround (target.transform.position, target.transform.up, angleStep * hCamInput);
		}
		if (Input.GetButton ("Fire2")) {
			transform.rotation = Quaternion.Slerp (transform.rotation, target.transform.rotation, 0.25f);
			//transform.rotation = Quaternion.LookRotation (target.transform.position - transform.position, Vector3.up);
			//transform.rotation = target.transform.rotation;
		}
	}
}
