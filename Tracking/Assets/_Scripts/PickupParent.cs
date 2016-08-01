using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	public Transform sphere; 
 
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
		
	/**If the touchpad is pressed, the sphere will be reset -- its position, velocity, and angular velocity will be all 
	   be transformed back to the 0 vector. **/
	void FixedUpdate () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index);

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			sphere.transform.position = new Vector3 (0.0528f, 0.166f, -1.073f); 
			sphere.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			sphere.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero; 
		}
		
	}

	void OnTriggerStay(Collider col) {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index);

		//If the trigger on the controller is pressed, set the sphere to be a child of the controller.
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//rigidBody will not be affected by the Physics system because it is being moved by our hands 
			col.attachedRigidbody.isKinematic = true; 
			col.gameObject.transform.SetParent (this.gameObject.transform);
		}

		//If the trigger on the controller is released, 
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			col.gameObject.transform.SetParent (null);
			col.attachedRigidbody.isKinematic = false; 

			tossObject (col.attachedRigidbody);
		}
	}

	/**tossObject takes a rigidBody and, if the origin point does exist, sets the velocity of the rigidbody to the world
		space's transform of that velocity. If the origin does not exist, it naively sets the rigidbody's velocity
		to that of the device. **/
	void tossObject(Rigidbody rigidBody) {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index);

		Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent; 

		//Converts the transforms from local space to world space for better accuracy 
		if (origin != null) {
			rigidBody.velocity = origin.TransformVector (device.velocity);
			rigidBody.angularVelocity = origin.TransformVector (device.angularVelocity);
		} 

		//naive approximation
		else {
			rigidBody.velocity = device.velocity; 
			rigidBody.angularVelocity = device.angularVelocity;
		}
	}
}
