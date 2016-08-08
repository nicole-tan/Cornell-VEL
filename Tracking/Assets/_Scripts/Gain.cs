using UnityEngine;
using System.Collections;

public class Gain : MonoBehaviour {
	protected GameObject firstOutput; 
	protected float firstGain; 
	protected GameObject secondOutput; 
	protected float secondGain; 

	private Vector3 change1; 
	private Vector3 change2; 
	private Vector3 before1;
	private Vector3 before2; 
	private Vector3 now1; 
	private Vector3 now2; 

	public GameObject actualLeftHand;


	// Use this for initialization
	void Start () {
		before1 = actualLeftHand.transform.position; 
		//before1 = GetComponent<StartClicked> ().leftHand.transform.position; 
		Debug.Log ("initial coords: " + before1);
		before2 = GetComponent<StartClicked> ().secondInpDropResult.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		firstGain = GetComponent<StoreGain> ().gain1; 
		secondGain = GetComponent<StoreGain> ().gain2; 

		now1 = actualLeftHand.transform.position; 
		//now1 =  GetComponent<StartClicked> ().leftHand.transform.position; 
		Debug.Log ("current position: " + now1);
		now2 =  GetComponent<StartClicked> ().secondInpDropResult.transform.position; 

		Debug.Log ("position before is: " + before1);
		change1 = now1 - before1;
		Debug.Log ("change in position: " + change1);
		change2 = now2 - before2; 


		firstOutput = actualLeftHand;
		//firstOutput = GetComponent<StartClicked> ().leftHand;
		secondOutput = GetComponent<StartClicked> ().secondInpDropResult;



		firstOutput.transform.position = new Vector3 (before1.x + (change1.x),
			before1.y + (change1.y), before1.z + (change1.z));
		Debug.Log ("new position: " + firstOutput.transform.position);
		secondOutput.transform.position = new Vector3 (secondOutput.transform.position.x + (change2.x), 
			secondOutput.transform.position.y + (change2.y), 
			secondOutput.transform.position.z + (change2.z)); 


		before1 = firstOutput.transform.position;
		before2 = now2; 
	}
}
