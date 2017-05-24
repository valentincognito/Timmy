using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;

	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();
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
