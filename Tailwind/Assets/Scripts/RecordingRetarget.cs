using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class RecordingRetarget : MonoBehaviour
{
	public void MakeXML()
	{
		var xmlser = new XmlSerializer(typeof(List<Frame>));
		xmlser.Serialize (System.IO.File.OpenWrite ("test-file.xml"), this.frames);
		// (List<Frame>)xmlser.Deserialize (System.IO.File.OpenRead ("test-file.xml"));
	}

	// https://answers.unity.com/questions/8500/how-can-i-get-the-full-path-to-a-gameobject.html
	public static string GetGameObjectPath(GameObject obj)
	{
		string path = "/" + obj.name;
		while (obj.transform.parent.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		return path;
	}

	[System.Serializable]
	public struct TransformSnapshot
	{
		public Vector3 position;
		public Quaternion rotation;
		public string name;
		public bool isActive;
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

	void Start ()
	{
		frames = new List<Frame>();
	}

	void LateUpdate ()
	{
		var newFrame = new Frame();
		foreach (var obj in objectsOfInterest)
		{
			var newSnapshot = new TransformSnapshot();
			newSnapshot.name = GetGameObjectPath(obj);
			newSnapshot.position = obj.transform.localPosition;
			newSnapshot.rotation = obj.transform.localRotation;
			newSnapshot.isActive = obj.activeInHierarchy;
			newFrame.snapshots.Add(newSnapshot);
		}

		frames.Add(newFrame);	
	}
}
