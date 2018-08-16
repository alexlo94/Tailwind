using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour {
	public bool reached;
	public Vector3 targetPosition;
	public Vector3 originalPosition;

	public Rigidbody rb; //the platform's rigidbody

	public float speed; //speed at which the platform moves between positions

	// Use this for initialization
	void Start () {
		originalPosition = this.gameObject.transform.position;
		rb = this.gameObject.GetComponent<Rigidbody> ();
		this.gameObject.GetComponent<BoxCollider> ().contactOffset = 1.0f;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player has Entered");
			StartCoroutine (MoveTo(originalPosition, targetPosition));
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player has Exited");
			StartCoroutine (MoveTo (targetPosition, originalPosition));
		}
	}

	IEnumerator MoveTo(Vector3 pos1, Vector3 pos2){
		while (Vector3.Distance (rb.position, pos2) >= 0.05f) {
			rb.MovePosition (Vector3.MoveTowards (rb.position, pos2, speed*Time.deltaTime));
			yield return null;
		}
	}
}
