using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	public int jumpMag;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * jumpMag);
		}
	}
}
