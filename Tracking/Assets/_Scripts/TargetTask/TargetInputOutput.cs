using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TargetInputOutput : MonoBehaviour {
	public GameObject input1dropdown;
	public GameObject output1dropdown;
	public GameObject input2dropdown;
	public GameObject output2dropdown;
	public GameObject timevisdropdown; 
	public GameObject bubsizedropdown;
	public GameObject numballoonsdropdown; 

	public GameObject leftController;
	public GameObject leftHand; 
	public GameObject rightController;
	public GameObject rightHand; 
	public GameObject leftFoot; 
	public GameObject rightFoot;

	public GameObject firstInpDropResult;
	public GameObject firstOutDropResult; 
	public GameObject secondInpDropResult;
	public GameObject secondOutDropResult; 
	public GameObject timeVisDropResult;
	public GameObject bubSizeDropResult;
	public GameObject numBalloonDropResult; 

	//Initialize listener as soon as your object loads into the scene; set default values for inputs and outputs
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
		Dropdown dropInp1 = input1dropdown.GetComponent<Dropdown> ();
		Dropdown dropOut1 = output1dropdown.GetComponent<Dropdown> ();
		Dropdown dropInp2 = input2dropdown.GetComponent<Dropdown> ();
		Dropdown dropOut2 = output2dropdown.GetComponent<Dropdown> ();
		Dropdown timeVis = timevisdropdown.GetComponent<Dropdown> ();
		Dropdown bubSize = bubsizedropdown.GetComponent<Dropdown> (); 
		Dropdown numBalloon = numballoonsdropdown.GetComponent<Dropdown> (); 

		//Add a listener to the event
		dropInp1.onValueChanged.AddListener(delegate {OnDropdownSelectFirst(dropInp1);}); 
		dropOut1.onValueChanged.AddListener (delegate {OnOutputDropdownSelectFirst(dropOut1);}); 
		dropInp2.onValueChanged.AddListener(delegate {OnDropdown2Select(dropInp2);}); 
		dropOut2.onValueChanged.AddListener (delegate {OnOutputDropdown2Select(dropOut2);}); 
		timeVis.onValueChanged.AddListener (delegate {OnTimeDropdownSelect (timeVis);});
		bubSize.onValueChanged.AddListener (delegate {OnBubbleSizeDropdownSelect (bubSize);});
		numBalloon.onValueChanged.AddListener (delegate {OnNumBubblesDropdownSelect (numBalloon);});

	}

	/**When a dropdown option is selected, firstInpDropResult is set to the corresponding value.
		The leftController is the parent if either the default or first option is chosen while
		the rightController is the parent if the second option is chosen. **/
	void OnDropdownSelectFirst(Dropdown drop){
		switch (drop.value) {
		case 0: 
			firstInpDropResult = leftController;
			break;

		case 1:
			firstInpDropResult = rightController;
			break;

			//Same as case 0
		default:
			firstInpDropResult = leftController;
			break;
		}
	}

	/**When a dropdown option is selected, firstOutDropResult is set to the corresponding value.
		The leftHand is the child if either the default or first option is chosen while
		the rightHand is the child if the second option is chosen. The leftFoot is the child
		if the third option is chosen. The rightFoot is the child if the fourth option 
		is chosen. **/
	void OnOutputDropdownSelectFirst(Dropdown drop) {
		switch (drop.value) {

		case 0: 
			firstOutDropResult = leftHand; 
			break;

		case 1: 
			firstOutDropResult = rightHand; 
			break;

		case 2:
			firstOutDropResult = leftFoot; 
			break;

		case 3:
			firstOutDropResult = rightFoot;
			break;

		default:
			firstOutDropResult = leftHand; 
			break; 
		}
	}

	/**When a dropdown option is selected, secondInpDropResult is set to the corresponding value.
		The rightController is the parent if either the default or first option is chosen while
		the leftController is the parent if the second option is chosen. **/
	void OnDropdown2Select(Dropdown drop){
		switch (drop.value) {
		case 0: 
			secondInpDropResult = rightController;
			break;

		case 1:
			secondInpDropResult = leftController;
			break;

			//Same as case 0
		default:
			secondInpDropResult = rightController;
			break;
		}
	}

	/**When a dropdown option is selected, secondOutDropResult is set to the corresponding value.
		The rightHand is the child if either the default or first option is chosen while
		the leftHand is the child if the second option is chosen. The leftFoot is the child 
		if the third option is chosen. The rightFoot is the child if the fourth option is 
		chosen. **/
	void OnOutputDropdown2Select(Dropdown drop) {
		switch (drop.value) {

		case 0: 
			secondOutDropResult = rightHand; 
			break;

		case 1: 
			secondOutDropResult = leftHand; 
			break;

		case 2:
			secondOutDropResult = leftFoot;
			break;

		case 3: 
			secondOutDropResult = rightFoot;
			break; 

		default:
			secondOutDropResult = rightHand; 
			break; 
		}
	}

	void OnTimeDropdownSelect(Dropdown drop) {
		DuplicateSelf dupSelf = GetComponent<DuplicateSelf> (); 

		switch (drop.value) {
		case 0: 
			dupSelf.lifetime = 10.0f; 
			break;

		case 1:
			dupSelf.lifetime = 5.0f;
			break;

		case 2:
			dupSelf.lifetime = 10.0f;
			break;

		case 3:
			dupSelf.lifetime = 15.0f;
			break;

		case 4:
			dupSelf.lifetime = 20.0f;
			break;

		default: 
			dupSelf.lifetime = 10.0f; 
			break;
		}
	} 

	void OnBubbleSizeDropdownSelect(Dropdown drop) {
		DuplicateSelf dupSelf = GetComponent<DuplicateSelf> (); 
		switch (drop.value) {
		case 0: 
			dupSelf.bubbleDimensions = 1.0f; 
			break;

		case 1:
			dupSelf.bubbleDimensions = 1.0f; 
			break;

		case 2:
			dupSelf.bubbleDimensions = 2.0f; 
			break;

		case 3:
			dupSelf.bubbleDimensions = 3.0f; 
			break;

		default: 
			dupSelf.bubbleDimensions = 1.0f;  
			break;
		}
	}

	void OnNumBubblesDropdownSelect(Dropdown drop) {
		DuplicateSelf dupSelf = GetComponent<DuplicateSelf> (); 
		switch (drop.value) {
		case 0: 
			dupSelf.numBubbles = 5; 
			break;

		case 1:
			dupSelf.numBubbles = 5; 
			break;

		case 2:
			dupSelf.numBubbles = 10; 
			break;

		case 3:
			dupSelf.numBubbles = 15;  
			break;

		case 4:
			dupSelf.numBubbles = 20;  
			break;

		default: 
			dupSelf.numBubbles = 5; 
			break;
		}
	} 

}
