using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayButtonBehavior : MonoBehaviour {
	public GameObject player;
	public GameObject replayPlayer;
	public PlaybackRetarget pbr;
	public RightCamera rcm;
	public GameObject endTextUI;
	public GameObject replayUI;

	//TODO: make camera controls work by adding a refernce to the rightcamera script and changing the target from TestPlayer to playbackTestPlayer

	// Use this for initialization
	void Start () {
		Button btn = this.gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	public void TaskOnClick(){
		Time.timeScale = 1.0f;
		player.tag = "Untagged";
		replayPlayer.tag = "Player";
		rcm.target = replayPlayer; //check if this is okay
		pbr.enabled = true;

		//hide menu layer
		replayUI.SetActive(true);
		endTextUI.SetActive(false);
		//show replay layer
			//replay layer has a skip to next level button on top/bottomleft'
			//display like the frame or smth?
			//blinking replay sign
	}
}
