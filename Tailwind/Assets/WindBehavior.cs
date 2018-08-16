using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : MonoBehaviour {

	public GameObject gManager;
	public WindManager wManager;

	public ParticleSystem pSystem;

	public float wSpeed = 5.0f;
	public Vector3 wVector;

	// Use this for initialization
	void Start () {
		wManager = gManager.GetComponent<WindManager> ();
		pSystem = gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//get the wind vector
		wVector = wManager.CalcWind(gameObject.transform);

		//apply the wind vector * speed to the particles
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[pSystem.particleCount + 1];
		int l = pSystem.GetParticles (p);

		for (int i = 0; i < l; i++) {
			p [i].velocity = wVector * wSpeed;
		}

		pSystem.SetParticles (p, 1);
	}
}
