using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class HeadController : Controller {

	void Start () {
		identifier = "Head";
		CreateCSV ();
	}

	//Called once every frame 
	void Update () {
		//ClearCSV (); 
		if (shouldUpdate == 1) {
			shouldUpdate = shouldUpdate + 1;
			SaveCSV ();
		} 
		else if (shouldUpdate == 2) {
			shouldUpdate = shouldUpdate + 1; 
		} 
		else {
			shouldUpdate = 1; 
		}
	} 

//	void FixedUpdate () {
//		WriteToCSV ();
//	}

		

	//If the h key is pressed, the previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.H))  
			System.IO.File.WriteAllText ("HeadController.csv", string.Empty);
	}

}
