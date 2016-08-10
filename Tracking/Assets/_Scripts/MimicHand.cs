using UnityEngine;
using System.Collections;

public class MimicHand : MonoBehaviour {
	public GameObject followedObject; 

	// Use this for initialization
	void Start () {
		transform.parent = followedObject.transform;
		//followPosition ();
		//transform.rotation = followedObject.transform.rotation; 

		//followRotation (); 
	}
	
	// Update is called once per frame
	void Update () {
		//followPosition ();
		//followRotation (); 
	}

	void followPosition() {
		transform.position = followedObject.transform.position; 
		//transform.parent = followedObject.transform;
	}

	void followRotation() {
		transform.rotation = followedObject.transform.rotation;
	} 
}
