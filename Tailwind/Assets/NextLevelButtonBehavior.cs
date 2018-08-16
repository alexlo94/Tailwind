using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelButtonBehavior : MonoBehaviour {
	public string nextSceneName;

	// Use this for initialization
	void Start () {
		Button btn = this.gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log("ButtonClicked");
		SceneManager.LoadScene (nextSceneName);
		//SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene());
	}
}
