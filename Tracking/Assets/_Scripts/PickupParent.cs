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
			//Debug.Log ("You are touching the trigger!");
		}
	} 


	void OnTriggerStay(Collider col) {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index); 
		//Debug.Log ("You have collided with " + col.name + "and activated OnTriggerStay");
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.Log ("You have collided with " + col.name + "while holding down Touch");
			//rigidBody will not be affected by the Physics system because it is being moved by our hands 
			col.attachedRigidbody.isKinematic = true; 
			col.gameObject.transform.SetParent (this.gameObject.transform);
		}
	}
}
