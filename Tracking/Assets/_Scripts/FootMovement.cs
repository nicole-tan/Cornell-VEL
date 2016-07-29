using UnityEngine;
using System.Collections;

public class FootMovement : MonoBehaviour {

	public GameObject headset; 

	// Use this for initialization
	void Start () {
		setPosition ();
	
	}
	
	// Update is called once per frame
	void Update () {
		setPosition (); 
	
	}

	void setPosition () {
		var headsetX = headset.transform.position.x; 
		var headsetY = headset.transform.position.y;
		var headsetZ = headset.transform.position.z;

		transform.position = new Vector3 (headsetX, headsetY - 1.5f, headsetZ); 
	}
}
