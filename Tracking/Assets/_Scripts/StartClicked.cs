using UnityEngine;
using System.Collections;

public class StartClicked : FirstInpOut {

	//The chosen controller becomes the parent of the respective chosen model
	public void ChangeParent() {
		Debug.Log ("ChangeParent is being called");
		Debug.Log ("firstOutDropResult is: " + firstOutDropResult);
		Debug.Log ("firstInpDropResult is: " + firstInpDropResult); 
		Debug.Log ("secondOutDropResult is: " + secondOutDropResult); 
		Debug.Log ("secondInpDropResult is: " + secondInpDropResult);
		firstOutDropResult.transform.parent = firstInpDropResult.transform;
		secondOutDropResult.transform.parent = secondInpDropResult.transform; 

	}
}
