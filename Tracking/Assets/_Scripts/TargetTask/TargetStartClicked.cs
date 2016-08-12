using UnityEngine;
using System.Collections;

public class TargetStartClicked : MonoBehaviour {
	private GameObject start_menu;
	
	public void HideVisibility() {
		start_menu = GameObject.Find ("/StartMenu");
		start_menu.SetActive (false);
	} 
}
