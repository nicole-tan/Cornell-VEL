using UnityEngine;
using System.Collections;
using UnityEditor; 

public class DialogueBox : MonoBehaviour {

	string userName;

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

	}
}
