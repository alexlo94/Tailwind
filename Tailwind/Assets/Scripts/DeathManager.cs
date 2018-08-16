using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour {
	
	public GameObject[] targets;
	public GameObject initSP;
	public int Ycutoff;
	public Vector3 spawnPoint;

	void Start(){
		spawnPoint = initSP.transform.position;
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < targets.Length; i++) {
			if (targets [i].transform.position.y <= Ycutoff) {
				targets [i].transform.position = spawnPoint;
			}
		}
		
	}
}
