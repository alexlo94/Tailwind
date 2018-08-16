using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CameraManager.cs by Alexandros Lotsos
//Script to manage the camera system in Tailwind.
//facilitates switching between 3rd person and top down cameras

public class CameraManager : MonoBehaviour {

	public Camera ThirdPersonCam, TopDownCam;
	public bool camSwitch = true;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire5")) {
			camSwitch = !camSwitch;
			ThirdPersonCam.gameObject.SetActive (camSwitch);
			TopDownCam.gameObject.SetActive (!camSwitch);
		}
	}
}
