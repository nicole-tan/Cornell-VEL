using UnityEngine;
using System.Collections;

public class Gain : MonoBehaviour {
	protected GameObject firstOutput; 
	protected float firstGain; 
	protected GameObject secondOutput; 
	protected float secondGain; 

	private Vector3 change1; 
	private Vector3 before1;
	private Vector3 change2; 
	private Vector3 before2; 


	// Use this for initialization
	void Start () {
		//before1 
	}
	
	// Update is called once per frame
	void Update () {
		firstGain = GetComponent<StoreGain> ().gain1; 
		secondGain = GetComponent<StoreGain> ().gain2; 
		firstOutput =  GetComponent<StartClicked> ().firstInpDropResult; 
		Debug.Log ("first output is: " + firstOutput);
		Debug.Log ("first gain is: " + firstGain); 
		secondOutput=  GetComponent<StartClicked> ().secondInpDropResult; 

		Debug.Log ("before transform:" + firstOutput.transform.position);
		firstOutput.transform.position = new Vector3 (firstOutput.transform.position.x * firstGain, 
										firstOutput.transform.position.y * firstGain, 
										firstOutput.transform.position.z * firstGain);
		Debug.Log ("after transform:" + firstOutput.transform.position);
		secondOutput.transform.position = new Vector3 (secondOutput.transform.position.x * secondGain, 
										secondOutput.transform.position.y * secondGain, 
										secondOutput.transform.position.z * secondGain); 
		
	}

	void Change() {
	}
}
