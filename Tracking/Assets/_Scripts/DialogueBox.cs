using UnityEngine;
using System.Collections;
using UnityEditor; 

public class DialogueBox : MonoBehaviour {

	string userName;
	string savedFileName;

	void OnGUI() {
		userName = EditorGUILayout.TextField ("User Name", userName);

		if (GUILayout.Button ("Save")) {
			OnClickSaveName (); 
		
		} 
	}


	void OnClickSaveName() {

		userName = userName.Trim ();

		if (string.IsNullOrEmpty (userName)) {
			EditorUtility.DisplayDialog ("Unable to save name", "Please enter a valid name.", "Close"); 
			return;
		}

		//Will be saved in the format 'username_date&timestamp'
		savedFileName = userName + System.DateTime.Now.ToString();
		//CHANGE: Append the controller and headset data as the second argument in this function once you consolidate files 
		System.IO.File.AppendAllText (savedFileName + ".csv", userName);
			
		//Close (); 

	}
}
