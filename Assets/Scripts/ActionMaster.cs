﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action
	{
		Tidy,
		Reset,
		EndTurn,
		EndGame
	}
	private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl(int pins){

		if(pins < 0 || pins > 10){
			throw new UnityException ("Invalid numbers of pins");
		}

		bowls [bowl - 1] = pins;

		if(bowl == 21){
			bowl += 1;
			return Action.EndGame;
		}

		// Handle last shot special cases
		if (bowl >= 19 && Bowl21Awarded ()) {
			bowl += 1;
			return Action.Reset;
		} else if(bowl == 20 && !Bowl21Awarded()) {
			return Action.EndGame;
		}

		// Strike test case
		if(pins == 10){
			bowl += 2;
			return Action.EndTurn;
		}

		// if this is the first bowl of the frame
		if(bowl % 2 != 0){
			bowl += 1;
			return Action.Tidy;
		}else if(bowl % 2 == 0){
			bowl += 1;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what action to return");
	}

	private bool Bowl21Awarded(){
		return (bowls [19 - 1] + bowls [20 - 1] >= 10);
	}
}
