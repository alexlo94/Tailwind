using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CollectibleBehavior.cs by Alexandros Lotsos
//Script to manage the behavior of collectible objects in Tailwind
//Collectibles will dissapear on contact with a player character and send a message to the scoremanager object of the level

public class CollectibleBehavior : MonoBehaviour {

	public GameObject gm; //container for the level's game manager
	public ScoreManager sm; //container for the game manager's scoremanager component

	public int colValue = 1; //score value of the collectible

	void Start(){
		gm = GameObject.Find ("Game Manager");
		sm = gm.GetComponent<ScoreManager> ();
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			//send message to scoremanager to increment score by 1
			sm.SendMessage("Score", colValue);
			gm.GetComponent<DeathManager> ().spawnPoint = this.gameObject.transform.position;

			//destroy yourself!
			gameObject.SetActive(false);
		}
	}
}
