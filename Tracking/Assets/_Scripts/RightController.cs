using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class RightController : Controller {

	void Start () {
		identifier = "RightController"; 	
		CreateCSV ();
	}

	//Called once every frame 
	void Update () {
		ClearCSV ();
		SaveCSV ();
	}

//	void FixedUpdate () {
//		WriteToCSV ();
//	}
		

	//If the r key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.R))  
			System.IO.File.WriteAllText ("RightController.csv", string.Empty);
	}
}