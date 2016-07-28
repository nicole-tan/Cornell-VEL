using UnityEngine;
using System.Collections;

public class LowerForearmMovements : MonoBehaviour {

	public GameObject wrist; 
		

	void FixedUpdate () {
		changeWristPosition ();
	
	}

	//changeWristPosition() gets the current transformation value of the wrist, multiplies the rotation along x by 0.5, and then sets
	//the lowerForearm's rotation to that new rotation amount 
	void changeWristPosition() {
		var wrist_pos = wrist.transform.eulerAngles; 
		Debug.Log ("Original wrist position: " + wrist_pos);
		wrist_pos.x = wrist_pos.x * 0.05f; 
		transform.eulerAngles = wrist_pos; 
		Debug.Log ("Lower forearm's position: " + wrist_pos);
	
	}
}
