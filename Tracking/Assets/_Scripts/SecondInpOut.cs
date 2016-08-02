using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class SecondInpOut : MonoBehaviour {
	public GameObject input2dropdown;
	public GameObject leftController;
	public GameObject leftHand; 
	public GameObject output2dropdown;
	public GameObject rightController;
	public GameObject rightHand; 

	protected GameObject secondInpDropResult;
	protected GameObject secondOutDropResult; 

	//Initialize as soon as your object loads into the scene
	void Awake () {
		AddListenerToDropdown (); 
	}

	//Adds a listener to the Dropdown's OnValueChange event
	void AddListenerToDropdown() {

		//Grab a reference to your Dropdown component
		Dropdown dropdown = input2dropdown.GetComponent<Dropdown>();
		Dropdown dropdown2 = output2dropdown.GetComponent<Dropdown> (); 

		//Add a listener to the event
		//dropdown.onValueChanged.AddListener(delegate {OnDropdownSelect(dropdown);}); 
		//dropdown2.onValueChanged.AddListener (delegate {OnOutputDropdownSelect(dropdown2);}); 
	}

	/**When a dropdown option is selected, firstInpDropResult is set to the corresponding value.
		The leftController is the parent if either the default or first option is chosen while
		the rightController is the parent if the second option is chosen. **/
	void OnDropdown2Select(Dropdown drop){
		switch (drop.value) {
		case 0: 
			secondInpDropResult = rightController;
			Debug.Log ("Right controller input has been chosen");
			break;

		case 1:
			secondInpDropResult = leftController;
			Debug.Log ("Left controller input has been chosen"); 
			break;

			//Same as case 0
		default:
			secondInpDropResult = rightController;
			Debug.Log ("Right controller input has been chosen");
			break;
		}
	}

	/**When a dropdown option is selected, firstOutDropResult is set to the corresponding value.
		The leftHand is the child if either the default or first option is chosen while
		the rightHand is the child if the second option is chosen. **/
	void OnOutputDropdown2Select(Dropdown drop) {
		switch (drop.value) {

		case 0: 
			secondOutDropResult = rightHand; 
			Debug.Log ("Right controller output has been chosen");
			break;

		case 1: 
			secondOutDropResult = leftHand; 
			Debug.Log ("Left controller output has been chosen");
			break;

		default:
			secondOutDropResult = rightHand; 
			Debug.Log ("Right controller output has been chosen");
			break; 
		}
	}
}
