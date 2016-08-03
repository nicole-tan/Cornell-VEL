using UnityEngine;
using System.Collections;

public class StartClicked : InputOuput {
	private GameObject start_menu; 
	public GameObject leftModel;
	public GameObject rightModel; 

	//The chosen controller becomes the parent of the respective chosen model
	//If any of the outputs are feet, call the FootChosen function on the hand,
	//disable the FootMovement script, and set the controller model to inactive
	public void ChangeParent() {
		firstOutDropResult.transform.parent = firstInpDropResult.transform;
		secondOutDropResult.transform.parent = secondInpDropResult.transform;

		if (firstOutDropResult == leftFoot || secondOutDropResult == leftFoot) {
			FootChosen (leftHand);
			leftFoot.GetComponent<FootMovement> ().enabled = false;
			leftModel.SetActive (false); 
			leftFoot.transform.position = leftModel.transform.position;
			leftFoot.transform.eulerAngles = new Vector3 (90, 180, leftModel.transform.eulerAngles.z);
		}

		if (firstOutDropResult == rightFoot || secondOutDropResult == rightFoot) {
			FootChosen (rightHand); 
			rightFoot.GetComponent<FootMovement> ().enabled = false;
			rightModel.SetActive (false); 
			rightFoot.transform.position = rightModel.transform.position; 
		} 

		start_menu = GameObject.Find ("/StartMenu");
		start_menu.SetActive (false);
	}

	//Set the arm corresponding to the given foot to inactive 
	public void FootChosen(GameObject correspondingArm){
		correspondingArm.SetActive (false);
	}    
}