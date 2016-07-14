using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class Controller : MonoBehaviour {

	public string identifier; 
	public string delimeter = ",";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Creates a new CSV file [if it does not already exist] and saves the date, time, and current position 
	//of the controller with the given name on a new line in the file 
	public void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 currRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

		string csvdata = System.DateTime.Now.ToString () + delimeter + currPos [0] + delimeter + currPos [1] +
		                 delimeter + currPos [2] + delimeter + currRot [0] + delimeter + currRot [1] + delimeter + currRot [2] +
		                 delimeter + identifier;

		if (identifier == "head") {
			csvcontent.AppendLine (csvdata); 
			System.IO.File.AppendAllText ("ConsolidatedData.csv", csvcontent.ToString());
		} 

		else if (identifier == "right") {
			csvcontent.AppendLine (csvdata); 
			System.IO.File.AppendAllText ("ConsolidatedData.csv", csvcontent.ToString());	
		}

		else {
			csvcontent.AppendLine (csvdata); 
			System.IO.File.AppendAllText ("ConsolidatedData.csv", csvcontent.ToString());	
		
		}

	}

	//When the user quits the application, add a series of asterisks and new lines to denote the delineation 
	//between run-throughs of the game.
	void OnApplicationQuit () {
		System.IO.File.AppendAllText ("ConsolidatedData.csv", "***************************************************************** \n \n \n");
	}
		
}
