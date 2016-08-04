using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class StoreGain : MonoBehaviour {
	protected string percentage1; 
	protected string percentage2; 
	public float gain1; 
	public float gain2; 

	public void RecordGain1(string inputValue) {
		Debug.Log ("in recordgain1"); 
		Debug.Log (inputValue); 
			percentage1 = inputValue; 
		Debug.Log (percentage1); 
	} 

	public void RecordGain2(string inputValue) {
		Debug.Log ("in recordgain2");
		percentage2 = inputValue; 
		Debug.Log (inputValue); 
	} 

	public void ConvertGain() {
		gain1 = float.Parse (percentage1);
		gain2 = float.Parse (percentage2); 
	
	} 
}
