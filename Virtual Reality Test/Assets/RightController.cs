using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class RightController : MonoBehaviour {

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
		System.IO.File.AppendAllText ("RightController.csv", csvcontent.ToString());

	}

	//If the space button is pressed, previous log of time, movement, and rotation is deleted. 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.Space))  
			System.IO.File.WriteAllText ("RightController.csv", string.Empty);
	}
}