using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSystemBehavior : MonoBehaviour {
	public WindManager wManager;

	// Use this for initialization
	void Start () {
		wManager = GameObject.Find ("Game Manager").GetComponent<WindManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation (wManager.CalcWind (gameObject.transform)), 0.1f);
		
	}
}
