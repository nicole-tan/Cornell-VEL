using UnityEngine;
using System.Collections;

public class MimicHand : MonoBehaviour {
	public GameObject followedObject; 

	// Use this for initialization
	void Start () {
		followPosition ();
		followRotation (); 
	}
	
	// Update is called once per frame
	void Update () {
		followPosition ();
		followRotation (); 
	}

	void followPosition() {
		transform.position = followedObject.transform.position; 
	}

	void followRotation() {
		transform.rotation = followedObject.transform.rotation;
	} 
}
