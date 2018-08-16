using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playback : MonoBehaviour {
	public bool playing = true;
	public int currentPlaybackFrame = 0;
	Recording recording;

	void Start () {
		recording = GetComponent<Recording>();
		recording.enabled = false;

		// clean up objects
		foreach (var obj in recording.objectsOfInterest)
		{
			Destroy(obj.GetComponent<Rigidbody>());
			Destroy(obj.GetComponent<Collider>());
		}
	}

	void Update()
	{
		var currentFrame = recording.frames[currentPlaybackFrame];
		foreach (var snapshot in currentFrame.snapshots)
		{
			snapshot.recordedObject.transform.position = snapshot.position;
			snapshot.recordedObject.transform.rotation = snapshot.rotation;
		}
		if (playing)
		{
			currentPlaybackFrame++;
			if (currentPlaybackFrame >= recording.frames.Count)
				currentPlaybackFrame = 0;
		}
	}
}






