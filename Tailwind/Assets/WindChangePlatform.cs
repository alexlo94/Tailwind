using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindChangePlatform : MonoBehaviour {
	public WindManager wm; //the wind manager in the game
	public int directionToChangeTo; //integer that indicates what direction the platform should change the wind towards

	// Use this for initialization
	void Start () {
		wm = GameObject.Find ("Game Manager").GetComponent<WindManager> ();
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			wm.currDir = directionToChangeTo;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Player") {
		}
	}
}
