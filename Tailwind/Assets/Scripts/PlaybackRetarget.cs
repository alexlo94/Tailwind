using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackRetarget : MonoBehaviour
{
	public bool playing = true;
	public int currentPlaybackFrame = 0;
	RecordingRetarget recording;

	void Start ()
	{
		recording = GetComponent<RecordingRetarget>();
		recording.MakeXML ();
		recording.enabled = false;
	}

	void FixedUpdate ()
	{
		var currentFrame = recording.frames[currentPlaybackFrame];
		foreach (var snapshot in currentFrame.snapshots)
		{
			// TODO probably slow :(
			var obj = GameObject.Find("/Playback Scene" + snapshot.name);
			if (obj != null) {
				obj.SetActive (snapshot.isActive);
				obj.transform.localPosition = snapshot.position;
				obj.transform.localRotation = snapshot.rotation;
			}
		}
		if (playing)
		{
			currentPlaybackFrame++;
			if (currentPlaybackFrame >= recording.frames.Count)
				currentPlaybackFrame = 0;
		}
	}
}
