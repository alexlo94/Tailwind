using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to create a moving platform using a target transform
//The transform is represented by a Vector3 object
//Alternative would be to do this with actual target transforms but who cares LMAO
public class PatrolPlatform : MonoBehaviour {
	
	public Vector3 targetPosition;
	public Vector3 originalPosition;

	public Rigidbody rb; //the platform's rigidbody

	public float speed; //speed at which the platform moves between positions

	// Use this for initialization
	void Start () {
		originalPosition = this.gameObject.transform.position;
		rb = this.gameObject.GetComponent<Rigidbody> ();

		StartCoroutine(MoveFromTo(originalPosition, targetPosition));
	}

	//coroutine to patrol between targetPosition and originalPosition
	IEnumerator MoveFromTo(Vector3 pos1, Vector3 pos2){
		Debug.Log ("Coroutine Started");
		//calculate velocity vector towards pos2
		//Vector3 vel = ((pos2 - pos1).normalized) * speed;
		//rb.velocity = vel;
		//Debug.Log (rb.velocity);
		while (Vector3.Distance (rb.position, pos2) >= 0.05f) {
			rb.MovePosition (Vector3.MoveTowards (rb.position, pos2, speed*Time.deltaTime));
			yield return null;
		}
		StartCoroutine (MoveFromTo (pos2, pos1));
	}
}
