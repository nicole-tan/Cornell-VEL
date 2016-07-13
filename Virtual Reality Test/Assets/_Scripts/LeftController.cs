using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


public class LeftController : MonoBehaviour {

	void Update () {
		ClearCSV (); 
	} 
	
	// Called for every physics step (a fixed interval between calls)
	void FixedUpdate () { 
		SaveCSV();
	}

	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion currRot = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); 
		csvcontent.AppendLine (System.DateTime.Now.ToString() + ",  Position: " + currPos.ToString() + ",  Rotation: " + currRot.ToString()); 
		System.IO.File.AppendAllText ("LeftController.csv", csvcontent.ToString());

	}

	//If the l key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.L))  
			System.IO.File.WriteAllText ("LeftController.csv", string.Empty);
	}

	//When the user quits the application, add a series of asterisks to denote the delineation between run-throughs of the game.
	void OnApplicationQuit () {
		System.IO.File.AppendAllText ("LeftController.csv", "*****************************************************************");
	}
}
