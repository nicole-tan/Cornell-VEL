using UnityEngine;
using System.Collections;
using System.Text;
using System.IO; 

public class UserController : MonoBehaviour {

	private Rigidbody rb; 
	private float speed = 10;

	/***** CONSTANTS *****/
	public Vector3 origin { get { return new Vector3(0, 0.5f, 0); } } 


	void Start () {
		//set reference to Rigidbody component on the same GameObject
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		ClearCSV (); 
	}

	//Called just before performing any Physics operations [will move by applying forces to Rigidbody]
	void FixedUpdate () {
		//record input from keypad 
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove); 

		rb.AddForce (movement * speed); 
		SaveCSV (); 
	}
		
	//Creates a new CSV file and saves the date, time, and current position of the ball on a new line 
	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		Vector3 currPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion currRot = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); 
		csvcontent.AppendLine (System.DateTime.Now.ToString() + "  Position: " + currPos.ToString() + "  Rotation: " + currRot.ToString()); 
		System.IO.File.AppendAllText ("CSVData.csv", csvcontent.ToString());

	}

	//Deletes previous log of time, movement, and rotation if the space button is pressed 
	void ClearCSV () { 
		if (Input.GetKeyDown(KeyCode.Space))  
			System.IO.File.WriteAllText ("CSVData.csv", string.Empty);
	}
		
}
