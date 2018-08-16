using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour
{
	[System.Serializable]
	public struct TransformSnapshot
	{
		public Vector3 position;
		public Quaternion rotation;
		public GameObject recordedObject; //TODO make me serializeable 
	}

	[System.Serializable]
	public class Frame
	{
		public List<TransformSnapshot> snapshots;
		public Frame()
		{
			snapshots = new List<TransformSnapshot>();
		}
	}

	public List<Frame> frames;
	public List<GameObject> objectsOfInterest;

	void Start()
	{
		frames = new List<Frame>();
	}

	void LateUpdate ()
	{
		var newFrame = new Frame();

		foreach (var obj in objectsOfInterest)
		{
			var newSnapshot = new TransformSnapshot();
			newSnapshot.recordedObject = obj;
			newSnapshot.position = obj.transform.localPosition;
			newSnapshot.rotation = obj.transform.localRotation;
			newFrame.snapshots.Add(newSnapshot);
		}

		frames.Add(newFrame);
	}
}
