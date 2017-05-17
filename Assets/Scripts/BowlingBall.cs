using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

	public float launchSpeed;

	private Rigidbody rigidBody;
	private AudioSource rollingSound;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rollingSound = GetComponent<AudioSource> ();

		Launch ();
	}

	void Launch ()
	{
		rigidBody.velocity = new Vector3 (0, 0, launchSpeed);
		rollingSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
