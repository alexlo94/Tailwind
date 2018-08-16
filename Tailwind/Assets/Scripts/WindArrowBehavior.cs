using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArrowBehavior : MonoBehaviour {
	public Transform player; //reference to player character
	public GameObject gm; //reference to the gamemanager object so that we can know where the wind is blowing
	public Vector3 positionOffset = new Vector3(-0.5f, 2.0f, -0.5f);
	
	// Update is called once per frame
	void Update () {
		//get the position of the player and follow him
		//rotate to the direction the wind is blowing in
		transform.rotation = Quaternion.LookRotation (gm.GetComponent<WindManager>().CalcWind(player.transform));
		transform.position = player.transform.position + positionOffset;
	}
}
