using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class Controller : DialogueBox {

	protected string identifier; 
	protected string delimeter = ",";
	public bool isRecording = true; 

	private string startTime; 

	void Awake () {
		startTime = System.DateTime.Now.ToString(); 
		//remove all backslashes
		startTime = startTime.Replace("/", "");
		//strip whitespaces from all areas
		startTime = startTime.Replace(" ", "");
		//replace colon with underscore
		startTime = startTime.Replace(":", "_");
	}

	//Creates a string with the milliseconds included
	private string fixTime () {
		string currTime = System.DateTime.Now.ToString (); 
		string newString = currTime + ":" + System.DateTime.Now.Millisecond.ToString(); 

		return newString; 
	}

	//Creates the first instance of a CSV file with the appropriate header 
	public void CreateCSV() {
		string header = "date-time,h_x,h_y,h_z,h_p,h_y,h_r,r_x,r_y,r_z,r_p,r_y,r_r,l_x,l_y,l_z,l_p,l_y,l_r \n";
		File.AppendAllText (startTime + "_" + userName + ".csv", header); 
	}

	//Creates a new CSV file [if it does not already exist] and saves the date, time, and current position 
	//of the controller with the given name on a new line in the file 
	public void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 currRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		string milliString = fixTime ();

		string csvdata = milliString + delimeter + currPos [0] + delimeter + currPos [1] +
			delimeter + currPos [2] + delimeter + currRot [0] + delimeter + currRot [1] + delimeter + currRot [2] +
			delimeter + identifier;


		csvcontent.AppendLine (csvdata);
		File.AppendAllText (startTime + "_" + userName + identifier + ".csv", csvcontent.ToString());	

	}

	//When the user quits the application, add a series of asterisks and new lines to denote the delineation 
	//between run-throughs of the game.
	void OnApplicationQuit () {
		System.IO.File.AppendAllText ("ConsolidatedData.csv", "***************************************************************** \n \n \n");
	}

	//Writes to CSV file initally. Once space button is pressed, set isRecording to the opposite bool. If it is true, save data to
	//the CSV file. If not, stop saving to the CSV. 
	public void WriteToCSV () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			isRecording = !isRecording; 
			CheckRecording (); 
		} 
		else {
			CheckRecording ();
		}
	}


	public void CheckRecording() {
		if (isRecording == true) {
			SaveCSV ();
		} 
	}
}
