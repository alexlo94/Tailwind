using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScoreManager.cs by Alexandros Lotsos
//Script to manage the score system in Tailwind.
//A given level should have a certain number of collectibles, C, that serve as the win condition
//Once the player collects all the collectibles the level ends

public class ScoreManager : MonoBehaviour {
	//holders for the total and current numbers of collectibles
	public int totalCol; //remember to set this in the editor!
	public int currCol;

	//array to store all the collectibles in the level
	public GameObject[] collectibles;

	// Use this for initialization
	void Start () {
		//find all collectibles in the level
		collectibles = GameObject.FindGameObjectsWithTag("Collectible");
		//loop through all the collectibles to determine the total number of points needed to beat the level
		int total = 0;
		for (int i = 0; i < collectibles.Length; i++) {
			total += collectibles [i].GetComponent<CollectibleBehavior> ().colValue;
		}
		totalCol = total;
		currCol = 0;
	}

	//method to increment the score by a certain number of points and check to see if the player has beat the level
	public void Score(int points){
		//add the points to the score
		currCol += points;

		//check to see if the player has won
		if (currCol >= totalCol) {
			//load the next scene
			Debug.Log("You did it!"); //for now just say something vaguely encouraging
		}
	}
}
