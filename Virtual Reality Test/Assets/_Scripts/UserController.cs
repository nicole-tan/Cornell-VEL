using UnityEngine;
using System.Collections;
using System.Text;
using System.IO; 

public class UserController : MonoBehaviour {

	private Rigidbody rb; 
	private float speed = 10; 
	//Unity equivalent of a constant
	public Vector3 origin { get { return new Vector3(0, 0.5f, 0); } } 

	void Start () {
		//set reference to Rigidbody component on the same GameObject
		rb = GetComponent<Rigidbody> ();
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
		
	void SaveCSV () {
		StringBuilder csvcontent = new StringBuilder ();
		csvcontent.AppendLine (System.DateTime.Now.ToString()); 
		System.IO.File.AppendAllText ("CSVData.csv", csvcontent.ToString());

	}
}
