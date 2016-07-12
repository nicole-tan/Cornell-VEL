using UnityEngine;
using System.Collections;
using System.Text;
using System.IO; 

public class UserController : MonoBehaviour {

	private Rigidbody rb; 
	private float speed = 10; 

	void Start () {
		//set reference to Rigidbody component on the same GameObject
		rb = GetComponent<Rigidbody> ();
		SaveCSV (); 
	}

	//Called just before performing any Physics operations [will move by applying forces to Rigidbody]
	void FixedUpdate () {
		//record input from keypad 
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove); 

		rb.AddForce (movement * speed); 
	}

	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		csvcontent.AppendLine ("Name,Age");
		csvcontent.AppendLine ("Nicole, 19"); 
		//string csvpath = "/saved_csv.csv";
		System.IO.File.WriteAllText ("CSVData.csv", csvcontent.ToString());

	}
}
