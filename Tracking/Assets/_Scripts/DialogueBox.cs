using UnityEngine;
using System.Collections;

public class DialogueBox : MonoBehaviour {

	public string userName = "";
	string savedFileName;

	void Start() {
		GUI.enabled = true; 

	}

	public string OnGUI () {
		userName = GUI.TextField (new Rect (500, 25, 100, 30), userName, 25);
		if (GUI.Button (new Rect (300, 250, 100, 30), "Submit")) {
			return userName;
		} 
		else {
			return "default name";
		}
	}


//	void OnClickSaveName() {
//
//		userName = userName.Trim ();
//
//		if (string.IsNullOrEmpty (userName)) {
//			EditorUtility.DisplayDialog ("Unable to save name", "Please enter a valid name.", "Close"); 
//			return;
//		}
//
//		//Will be saved in the format 'username_date&timestamp'
//		savedFileName = userName + System.DateTime.Now.ToString();
//		//CHANGE: Append the controller and headset data as the second argument in this function once you consolidate files 
//		System.IO.File.AppendAllText (savedFileName + ".csv", userName);
//			
//		//Close (); 
//
//	}
}
