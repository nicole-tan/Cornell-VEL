using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


public class LeftController : MonoBehaviour {

	bool isRecording = true;

	//Called once every frame 
	void Update () {
		ClearCSV ();
		WriteToCSV ();
	} 
	
	// Called for every physics step (a fixed interval between calls)
	void FixedUpdate () { 
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
		System.IO.File.AppendAllText ("LeftController.csv", csvcontent.ToString());

	}

	//If the l key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.L))  
			System.IO.File.WriteAllText ("LeftController.csv", string.Empty);
	}

	//When the user quits the application, add a series of asterisks and new lines to denote the delineation 
	//between run-throughs of the game.
	void OnApplicationQuit () {
		System.IO.File.AppendAllText ("LeftController.csv", "***************************************************************** \n \n \n");
	}

	//Writes to CSV file initally. Once space button is pressed, set isRecording to the opposite bool. If it is true, save data to
	//the CSV file. If not, stop saving to the CSV. 
	void WriteToCSV () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			isRecording = !isRecording; 
			CheckRecording (); 
		} 
		else {
			CheckRecording ();
		}
	}

	//Saves to CSV file if isRecording is true. Does nothing if isRecording is false. 
	void CheckRecording() {
		if (isRecording == true) {
			SaveCSV ();
		} 
	}
}
