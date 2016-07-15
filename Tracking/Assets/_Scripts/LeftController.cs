using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LeftController : Controller {

	void Start () {
		identifier = "left"; 
		CreateCSV ();
	}

	//Called once every frame 
	void Update () {
		ClearCSV (); 
	} 

	void FixedUpdate () {
		WriteToCSV ();
	}


	//If the l key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.L))  
			System.IO.File.WriteAllText ("LeftController.csv", string.Empty);
	}
		
}