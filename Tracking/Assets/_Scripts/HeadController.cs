using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class HeadController : MonoBehaviour {

	//Called once every frame 
	void Update () {
		ClearCSV (); 
	} 

	// Called for every physics step (a fixed interval between calls)
	void FixedUpdate () { 
		SaveCSV();
	}

	//Creates a new CSV file [if it does not already exist] and saves the date, time, and current position 
	//of the left controller on a new line in the file 
	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion currRot = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, 
			transform.rotation.w); 
		csvcontent.AppendLine (System.DateTime.Now.ToString() + ",  Position: " + 
			currPos.ToString() + ",  Rotation: " + currRot.ToString()); 
		System.IO.File.AppendAllText ("HeadController.csv", csvcontent.ToString());

	}

	//If the h key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.H))  
			System.IO.File.WriteAllText ("HeadController.csv", string.Empty);
	}

	//When the user quits the application, add a series of asterisks and new lines to denote the delineation 
	//between run-throughs of the game.
	void OnApplicationQuit () {
		System.IO.File.AppendAllText ("HeadController.csv", "***************************************************************** \n \n \n");
	}
}
