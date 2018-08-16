using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CameraController.cs by Alexandros Lotsos
//Script to implement camera controls for tailwind

public class CameraController : MonoBehaviour {

	public float distanceAway;
	public float distanceUp;
	public float smooth;

	private Transform follow;
	private Vector3 targetPosition;

	//calculate the offset on start
	void Start () {
		follow = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	//use lateUpdate to allow playerinput to move the character first
	void LateUpdate(){
		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt (follow);
	}
}
