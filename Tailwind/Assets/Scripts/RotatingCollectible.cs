﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCollectible : MonoBehaviour {
	public float speed = 10f;

	void Update(){
		transform.Rotate (transform.up, speed*Time.deltaTime);
	}
}
