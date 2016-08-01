using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Menu : MonoBehaviour {
	public GameObject input1dropdown;
	public GameObject leftController;
	public GameObject rightController; 

	//Initialize as soon as your object loads into the scene
	void Awake () {
		AddListenerToDropdown (); 
	}

	//Add a listener to the Dropdown's OnValueChange event
	void AddListenerToDropdown() {

		//Grab a reference to your Dropdown component
		Dropdown dropdown = input1dropdown.GetComponent<Dropdown>();

		//Add a listener to the event
		dropdown.onValueChanged.AddListener(delegate {OnDropdownSelect(dropdown);}); 
	}


	void OnDropdownSelect(Dropdown drop){
		switch (drop.value) {
		case 0: 
			Debug.Log ("Left controller has been chosen");
			break;

		case 1:
			Debug.Log ("Right controller has been chosen"); 
			break;

		default:
			Debug.Log ("Default has been chosen");
			break;
		}
	}
}
