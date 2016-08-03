using UnityEngine;
using System.Collections;

public class StartClicked : InputOuput {
	private GameObject start_menu; 

	//The chosen controller becomes the parent of the respective chosen model
	public void ChangeParent() {
		firstOutDropResult.transform.parent = firstInpDropResult.transform;
		secondOutDropResult.transform.parent = secondInpDropResult.transform;

		if (firstOutDropResult == leftFoot) {
			FootChosen (leftHand);
			leftFoot.GetComponent<FootMovement> ().enabled = false;
		}

		if (firstOutDropResult == rightFoot) {
			FootChosen (rightHand); 
			rightFoot.GetComponent<FootMovement> ().enabled = false;
		} 

		start_menu = GameObject.Find ("/StartMenu");
		start_menu.SetActive (false);
	}

	public void FootChosen(GameObject correspondingArm){
		correspondingArm.SetActive (false);
	}	
}
