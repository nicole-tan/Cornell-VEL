using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LeftController : Controller {

	bool isRecording = true; 

	void Start () {
		identifier = "left"; 	
	}

	//Called once every frame 
	void Update () {
		ClearCSV ();
		WriteToCSV (); 
	} 


	//If the l key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.L))  
			System.IO.File.WriteAllText ("LeftController.csv", string.Empty);
	}

//	//When the user quits the application, add a series of asterisks and new lines to denote the delineation 
//	//between run-throughs of the game.
//	void OnApplicationQuit () {
//		System.IO.File.AppendAllText ("LeftController.csv", "***************************************************************** \n \n \n");
//	}

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