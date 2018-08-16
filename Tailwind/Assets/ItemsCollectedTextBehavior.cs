using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollectedTextBehavior : MonoBehaviour {
	public GameObject gm; //reference to the gamemanager object for scoresetting

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "You got " + gm.GetComponent<ScoreManager> ().currCol + "/" + gm.GetComponent<ScoreManager> ().totalCol + " collectibles";
	}
}
