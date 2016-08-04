using UnityEngine;
using System.Collections;

public class Gain : MonoBehaviour {
	protected GameObject firstOutput; 
	protected float firstGain; 
	protected GameObject secondOutput; 
	protected float secondGain; 

	// Use this for initialization
	void Start () {
		firstGain = GetComponent<StoreGain> ().gain1; 
		secondGain = GetComponent<StoreGain> ().gain2; 
	}
	
	// Update is called once per frame
	void Update () {
		firstOutput =  GetComponent<StartClicked> ().firstOutDropResult; 
		secondOutput=  GetComponent<StartClicked> ().secondOutDropResult; 

		firstOutput.transform.position = new Vector3 (firstOutput.transform.position.x * firstGain, 
										firstOutput.transform.position.y * firstGain, 
										firstOutput.transform.position.z * firstGain);
		secondOutput.transform.position = new Vector3 (secondOutput.transform.position.x * secondGain, 
										secondOutput.transform.position.y * secondGain, 
										secondOutput.transform.position.z * secondGain); 
		
	}
}
