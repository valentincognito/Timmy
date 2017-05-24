using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

	public bool inPlay = false;
	private Rigidbody rigidBody;
	private AudioSource rollingSound;
	private Vector3 bowlingBallStartPos;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rollingSound = GetComponent<AudioSource> ();

		rigidBody.useGravity = false;

		bowlingBallStartPos = transform.position;
	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		rollingSound.Play ();
	}

	public void Reset(){
		inPlay = false;
		transform.position = bowlingBallStartPos;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if(DragLaunch.dragstart){
			//MoveWithTouch(Input.mousePosition);
		}
	}

	public void MoveWithTouch(Vector3 touchPos){
		transform.position = touchPos;
	}

}
