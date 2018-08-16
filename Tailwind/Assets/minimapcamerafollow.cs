using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapcamerafollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(GameObject.FindGameObjectWithTag ("Player").transform.position.x, 45.0f, GameObject.FindGameObjectWithTag ("Player").transform.position.z);
	}
}
