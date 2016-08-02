using UnityEngine;
using System.Collections;

public class StartClicked : FirstInpOut {

	//The chosen controller becomes the parent of the respective chosen model
	public void ChangeParent() {
		firstOutDropResult.transform.parent = firstInpDropResult.transform;
		secondOutDropResult.transform.parent = secondInpDropResult.transform; 

	}
}
