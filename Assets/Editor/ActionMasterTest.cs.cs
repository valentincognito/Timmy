using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}


}
