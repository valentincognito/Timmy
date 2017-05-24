using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public BowlingBall bowlingBall;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - bowlingBall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(bowlingBall.transform.position.z <= 1500f){
			transform.position = bowlingBall.transform.position + offset;
		}
	}
}
