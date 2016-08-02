using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class FirstInpOut : MonoBehaviour {
	public GameObject input1dropdown;
	public GameObject output1dropdown;
	public GameObject input2dropdown;
	public GameObject output2dropdown;
	public GameObject leftController;
	public GameObject leftHand; 
	public GameObject rightController;
	public GameObject rightHand; 

	protected GameObject firstInpDropResult;
	protected GameObject firstOutDropResult; 
	protected GameObject secondInpDropResult;
	protected GameObject secondOutDropResult; 



	//Initialize as soon as your object loads into the scene
	void Awake () {
		AddListenerToDropdown (); 
		firstInpDropResult = leftController;
		firstOutDropResult = leftHand; 
		secondInpDropResult = rightController;
		secondOutDropResult = rightHand; 
	}

	//Adds a listener to the Dropdown's OnValueChange event
	void AddListenerToDropdown() {

		//Grab a reference to your Dropdown component
		Dropdown dropdown_inp1 = input1dropdown.GetComponent<Dropdown>();
		Dropdown dropdown_out1 = output1dropdown.GetComponent<Dropdown> (); 
		Dropdown dropdown_inp2 = input2dropdown.GetComponent<Dropdown>();
		Dropdown dropdown_out2 = output2dropdown.GetComponent<Dropdown> (); 

		//Add a listener to the event
		dropdown_inp1.onValueChanged.AddListener(delegate {OnDropdownSelectFirst(dropdown_inp1);}); 
		dropdown_out1.onValueChanged.AddListener (delegate {OnOutputDropdownSelectFirst(dropdown_out1);}); 
		dropdown_inp2.onValueChanged.AddListener(delegate {OnDropdown2Select(dropdown_inp2);}); 
		dropdown_out2.onValueChanged.AddListener (delegate {OnOutputDropdown2Select(dropdown_out2);}); 
	}

	/**When a dropdown option is selected, firstInpDropResult is set to the corresponding value.
		The leftController is the parent if either the default or first option is chosen while
		the rightController is the parent if the second option is chosen. **/
	void OnDropdownSelectFirst(Dropdown drop){
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
	void OnOutputDropdownSelectFirst(Dropdown drop) {
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
