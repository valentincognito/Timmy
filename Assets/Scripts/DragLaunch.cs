using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BowlingBall))]
public class DragLaunch : MonoBehaviour {

	private BowlingBall bowlingBall;
	private float dragStartTime, dragTime;
	private Vector3 dragStartPos, dragDiffPos;

	public static bool dragstart = false;

	// Use this for initialization
	void Start () {
		bowlingBall = GetComponent<BowlingBall> ();
	}
	
	public void DragStart(){
		dragStartTime = Time.time;
		dragStartPos = Input.mousePosition;

		dragstart = true;
	}

	public void DragEnd(){
		dragTime = Time.time - dragStartTime;
		dragDiffPos = Input.mousePosition - dragStartPos;

		float speedY = (dragDiffPos.y / dragTime);
		float speedX = (dragDiffPos.x / dragTime);

		bowlingBall.Launch (new Vector3(speedX, 0f, speedY));

		dragstart = false;
	}
}
