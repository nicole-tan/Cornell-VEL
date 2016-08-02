using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class FirstInpOut : SecondInpOut {
	public GameObject input1dropdown;
	public GameObject output1dropdown;


	protected GameObject firstInpDropResult;
	protected GameObject firstOutDropResult; 

	//Initialize as soon as your object loads into the scene
	void Awake () {
		AddListenerToDropdown (); 
	}

	//Adds a listener to the Dropdown's OnValueChange event
	void AddListenerToDropdown() {

		//Grab a reference to your Dropdown component
		Dropdown dropdown = input1dropdown.GetComponent<Dropdown>();
		Dropdown dropdown2 = output1dropdown.GetComponent<Dropdown> (); 

		//Add a listener to the event
		dropdown.onValueChanged.AddListener(delegate {OnDropdownSelect(dropdown);}); 
		dropdown2.onValueChanged.AddListener (delegate {OnOutputDropdownSelect(dropdown2);}); 
	}

	/**When a dropdown option is selected, firstInpDropResult is set to the corresponding value.
		The leftController is the parent if either the default or first option is chosen while
		the rightController is the parent if the second option is chosen. **/
	void OnDropdownSelect(Dropdown drop){
		switch (drop.value) {
		case 0: 
			firstInpDropResult = leftController;
			Debug.Log ("Left controller input has been chosen");
			break;

		case 1:
			firstInpDropResult = rightController;
			Debug.Log ("Right controller input has been chosen"); 
			break;

		//Same as case 0
		default:
			firstInpDropResult = leftController;
			Debug.Log ("Left controller input has been chosen");
			break;
		}
	}

	/**When a dropdown option is selected, firstOutDropResult is set to the corresponding value.
		The leftHand is the child if either the default or first option is chosen while
		the rightHand is the child if the second option is chosen. **/
	void OnOutputDropdownSelect(Dropdown drop) {
		switch (drop.value) {

		case 0: 
			firstOutDropResult = leftHand; 
			Debug.Log ("Left controller output has been chosen");
			break;
		
		case 1: 
			firstOutDropResult = rightHand; 
			Debug.Log ("Right controller output has been chosen");
			break;

		default:
			firstOutDropResult = leftHand; 
			Debug.Log ("Left controller output has been chosen");
			break; 
		}
	}
}
