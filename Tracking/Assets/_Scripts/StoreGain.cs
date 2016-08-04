using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class StoreGain : MonoBehaviour {
	protected string percentage1; 
	protected string percentage2; 
	public float gain1; 
	public float gain2; 

	void Awake () {
		gain1 = 1.0f;
		gain2 = 1.0f; 
	} 

	public void RecordGain1(string inputValue) {
			percentage1 = inputValue; 
	} 

	public void RecordGain2(string inputValue) {
		percentage2 = inputValue; 
	} 

	public void ConvertGain() {
		gain1 = float.Parse (percentage1);
		gain2 = float.Parse (percentage2); 
	
	} 
}
