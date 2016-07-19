using UnityEngine;
using System.Collections;

public class HandMovements : SteamVR_ControllerManager {
	public GameObject leftHand;
	public GameObject rightHand; 

	void Update() {
		leftHand.transform.position = left.transform.position;
		rightHand.transform.position = right.transform.position; 
	}


}
