using UnityEngine;
using UnityEngine.UI;

public class WindDirectionTextBehavior : MonoBehaviour {
	public GameObject gm; //reference to the gamemanager object
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "Wind Direction: " + gm.GetComponent<WindManager> ().wDir + "\n" + "Wind Intensity: " + gm.GetComponent<WindManager> ().wInt;
	}
}
