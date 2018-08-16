using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour {
	public float strength = 100;
	void Start () {
		GetComponent<Rigidbody>().AddForce(transform.up * strength, ForceMode.VelocityChange);
	}
}
