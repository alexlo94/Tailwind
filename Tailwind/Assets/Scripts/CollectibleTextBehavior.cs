using UnityEngine;
using UnityEngine.UI;

public class CollectibleTextBehavior : MonoBehaviour {
	public GameObject gm; //reference to the gamemanager object for scoresetting

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "Collectibles: " + gm.GetComponent<ScoreManager> ().currCol + "/" + gm.GetComponent<ScoreManager> ().totalCol;
	}
}
