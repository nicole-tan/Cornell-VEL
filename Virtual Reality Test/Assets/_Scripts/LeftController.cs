using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class LeftController : MonoBehaviour {

	//SteamVR_TrackedObject trackedObj;

	// Run whether or not the GameObject is enabled 
	void Awake () {
		//trackedObj = GetComponent<SteamVR_TrackedObject> (); 
	
	}
	
	// Called for every physics step (a fixed interval between calls)
	void FixedUpdate () {
		//SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedObj.index); 
		SaveCSV();
	}

	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion currRot = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); 
		csvcontent.AppendLine (System.DateTime.Now.ToString() + "  Position: " + currPos.ToString() + "  Rotation: " + currRot.ToString()); 
		System.IO.File.AppendAllText ("LeftController.csv", csvcontent.ToString());

	}
}
