using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;

	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private BowlingBall bowlingBall;

	// Use this for initialization
	void Start () {
		bowlingBall = GameObject.FindObjectOfType<BowlingBall> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(ballEnteredBox){
			standingDisplay.text = CountStanding ().ToString ();
			CheckStanding ();
		}
	}

	void CheckStanding(){
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinHaveSettled ();
		}
	}

	void PinHaveSettled(){
		bowlingBall.Reset ();
		lastStandingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding(){
		int standCount = 0;

		foreach(BowlingPin pin in GameObject.FindObjectsOfType <BowlingPin>()){
			if(pin.IsStanding()){
				standCount++;
			}
		}

		return standCount;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.GetComponent<BowlingBall>()){
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if(collider.gameObject.GetComponent<BowlingPin>()){
			Destroy(collider.gameObject);
		}
	}
}
