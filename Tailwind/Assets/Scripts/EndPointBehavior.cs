using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointBehavior : MonoBehaviour {
	public GameObject UIText;
	public GameObject NextLevelText;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Time.timeScale = 0;
			UIText.gameObject.active = false;
			NextLevelText.gameObject.active = true;
		}
	}
}
