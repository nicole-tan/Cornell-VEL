using UnityEngine;
using System.Collections;

public class StartClicked : InputOuput {
	private GameObject start_menu;

	//The chosen controller becomes the parent of the respective chosen model
	public void ChangeParent() {
		firstOutDropResult.transform.parent = firstInpDropResult.transform;
		secondOutDropResult.transform.parent = secondInpDropResult.transform; 

		start_menu = GameObject.Find ("/StartMenu");
		start_menu.SetActive (false);
	}
}
