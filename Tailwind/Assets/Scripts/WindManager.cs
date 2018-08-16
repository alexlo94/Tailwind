using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WindManager.cs by Alexandros Lotsos
//Script to manage the wind system in Tailwind.
//Camera default lookat axis towards the player is the Z-axis so let Z -> N/S and let X -> E/W
//TODO: replace string/elseif with an enum/switch statement

public class WindManager : MonoBehaviour {
	private string[] wDirections = {"N", "NE", "E", "SE", "S", "SW", "W", "NW"};
	public int currDir = 0;

	public bool autoWind = false; //enable this to start the autowind change function
	public int minDir = 0;
	public int maxDir = 7;
	public float time = 0.0f;

	public string wDir;
	public float wInt = 5;

	void Start(){
		if (autoWind) {
			StartCoroutine ("ChangeWind");
		}
	}

	void Update(){
		//adjust wDir based on the difference
		if (wDir != wDirections [currDir]) {
			wDir = wDirections [currDir];
		}

		//check to see if for any reason autowind has stopped
		if (!autoWind) {
			StopCoroutine ("ChangeWind");
		}

		//check to see if player is trying to change the intensity of the wind

	}

	//method to calculate wind force at a specific point in space
	public Vector3 CalcWind(Transform target){
		if (wDir == "N") {
			return new Vector3 (0, 0, wInt);
		} else if (wDir == "S") {
			return new Vector3 (0, 0, -wInt);
		} else if (wDir == "E") {
			return new Vector3 (wInt, 0, 0);
		} else if (wDir == "W") {
			return new Vector3 (-wInt, 0, 0);
		} else if (wDir == "NE") {
			return (new Vector3(1, 0, 1).normalized)*wInt;
		} else if (wDir == "NW") {
			return (new Vector3(-1, 0, 1).normalized)*wInt;
		} else if (wDir == "SE") {
			return (new Vector3(1, 0, -1).normalized)*wInt;
		} else if (wDir == "SW") {
			return (new Vector3(-1, 0, -1).normalized)*wInt;
		} else {
			//there's something wrong, return a 0 wind Value
			return Vector3.zero;
		}
	}

	//method to use a mathematical modulus operator
	static int MathMod(int a, int b) {
		return (Mathf.Abs(a * b) + a) % b;
	}

	//coroutine to handle the autowindchange direction
	IEnumerator ChangeWind(){
		while (true) {
			//roll a random number between the two bounds minDir and maxDir
			int r = Random.Range(minDir, maxDir);
			//set the current wind direction to the number rolled
			currDir = r;
			//wait for the appropriate time
			yield return new WaitForSeconds(time);
		}
	}
}
