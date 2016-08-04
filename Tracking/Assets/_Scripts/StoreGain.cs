using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class StoreGain : MonoBehaviour {
	public string percentage1; 
	public string percentage2; 

	void Awake() {
		percentage1 = "1.0f";
		percentage2 = "1.0f"; 
	}

	public void RecordGain(string inputValue) {
		if (this.name == "PercentageInput1") {
			percentage1 = inputValue; 
		} 

		else {
			percentage2 = inputValue; 
		}

	} 
}
