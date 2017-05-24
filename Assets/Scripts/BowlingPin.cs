﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour {

	public float standingTreshold;
	public float distanceToRaise = 40f;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);


		if (tiltInX < standingTreshold && tiltInZ < standingTreshold) {
			return true;
		} else {
			return false;
		}
	}

	public void Raise(){
		rigidBody.useGravity = false;
		if(IsStanding()){
			transform.Translate (new Vector3(0, distanceToRaise, 0), Space.World);
		}

	}
	public void Lower(){
		transform.Translate (new Vector3(0, -distanceToRaise, 0), Space.World);
		rigidBody.useGravity = true;
	}

	public void Renew(){

	}
}
