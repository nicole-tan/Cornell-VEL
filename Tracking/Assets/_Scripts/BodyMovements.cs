﻿using UnityEngine;
using System.Collections;

public class BodyMovements : MonoBehaviour {
	public GameObject headset; 
	private Vector3 initRotation; 
	private Vector3 initPosition; 

	// Use this for initialization
	void Start () {
		setPosition (); 
		initPosition = headset.transform.position; 
		transform.rotation = headset.transform.rotation;
		initRotation = headset.transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {
		setPosition ();
		setRotation (); 
	}

	void setPosition() {
		var headsetX = headset.transform.position.x;
		var headsetY = headset.transform.position.y;
		var headsetZ = headset.transform.position.z; 

		transform.position = new Vector3 (headsetX, headsetY, headsetZ);

	}

	void setRotation() {
		transform.eulerAngles = new Vector3 (initRotation.x, headset.transform.eulerAngles.y, initRotation.z);
	}
}