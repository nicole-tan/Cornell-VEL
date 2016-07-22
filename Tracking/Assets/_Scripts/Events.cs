using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class Events : MonoBehaviour {
	
	protected string identifier; 
	protected string delimeter = ",";
	
	void FixedUpdate() {
		EventPress (); 
	}

	public void EventPress () {
		if (Input.GetKeyDown (KeyCode.E)) {
			SaveEvent ();
		}
	}
		

	public void SaveEvent () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 currRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

		string csvdata = System.DateTime.Now.ToString () + delimeter + currPos [0] + delimeter + currPos [1] +
			delimeter + currPos [2] + delimeter + currRot [0] + delimeter + currRot [1] + delimeter + currRot [2] +
			delimeter + identifier;

		csvcontent.AppendLine (csvdata); 
		System.IO.File.AppendAllText ("Events.csv", "E has been pressed!" + csvcontent.ToString());

	}


}
