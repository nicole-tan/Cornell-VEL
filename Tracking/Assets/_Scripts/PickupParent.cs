using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;

	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void FixedUpdate () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index); 

		//holding trigger down, but not all the way
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are touching the trigger!");
		}
	} 


	void OnTriggerStay(Collider col) {
	
	}
}
