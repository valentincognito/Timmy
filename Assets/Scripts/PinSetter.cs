using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject PinSet;

	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	private BowlingBall bowlingBall;
	private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;

	// Use this for initialization
	void Start () {
		bowlingBall = GameObject.FindObjectOfType<BowlingBall> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(ballEnteredBox){
			standingDisplay.text = CountStanding ().ToString ();
			UpdateStandingCountAndSettle ();
		}
	}

	public void RaisePins(){
		foreach(BowlingPin pin in GameObject.FindObjectsOfType <BowlingPin>()){
			pin.Raise ();
		}
	}
	public void LowerPins(){
		foreach(BowlingPin pin in GameObject.FindObjectsOfType <BowlingPin>()){
			pin.Lower ();
		}
	}

	public void RenewPins(){
		GameObject newPins = Instantiate (PinSet);
		newPins.transform.position += new Vector3 (0, 20, 0);
	}

	void UpdateStandingCountAndSettle(){
		int currentStanding = CountStanding ();

		// Check if the pins are still moving
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;
		// If the pins haven't move for more than the settleTim then settle
		if ((Time.time - lastChangeTime) > settleTime) {
			PinHaveSettled ();
		}
	}

	void PinHaveSettled(){
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);

		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger ("tidyTrigger");
		}else if(action == ActionMaster.Action.EndTurn){
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		}else if(action == ActionMaster.Action.Reset){
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		}


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
