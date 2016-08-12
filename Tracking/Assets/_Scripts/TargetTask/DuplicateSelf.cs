using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class DuplicateSelf : MonoBehaviour {
	public GameObject bubble;
	public GameObject plane; 
	//time the bubble is visible 
	public float lifetime = 10.0f; 
	public int numBubbles = 5; 
	public float planeX;
	public float planeY;
	public float planeZ; 
	public float bubbleDimensions;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			GameObject newObj = (GameObject) Instantiate (bubble, createRandomPos(), Quaternion.identity);
			newObj.tag = "bubble"; 
			newObj.GetComponent<Rigidbody> ().useGravity = false; 
			newObj.transform.localScale = createRandomSize ();
			Destroy (newObj, lifetime);

			InvokeRepeating ("createNewBubbles", 2, 5);
		}
	}


	//Creates a Vector3 with random coordinates within the limitations of the plane .
	Vector3 createRandomPos() {
		//float randomY = Random.Range (plane.transform.position.y - plane.transform.localScale.y/2, plane.transform.position.y + plane.transform.localScale.y/2);
		float randomY = Random.Range (0.3f, 2.0f);
		float randomZ = Random.Range (-2.8f, -0.7f);
		return new Vector3 (0.972f, randomY, randomZ); 
	} 

	//Creates a Vector3 that gives a random bubble size from 0.09 to 0.30.
	Vector3 createRandomSize() {
		float randomSize = Random.Range (0.09f, 0.30f); 
		return new Vector3 (randomSize, randomSize, randomSize); 
	}

	//Creates the number of bubbles indicated by numBubbles with a random position and size as well as the "bubble" tag. The object
	//created is destroyed after 'lifetime' number of seconds. 
	void createNewBubbles() {
		for (var i = 0; i < numBubbles; i++) {
			GameObject newObj = (GameObject) Instantiate (bubble, createRandomPos(), Quaternion.identity);
			newObj.tag = "bubble"; 
			newObj.GetComponent<Rigidbody> ().useGravity = false; 
			newObj.transform.localScale = createRandomSize ();
			Destroy (newObj, lifetime);
		} 
	}

}
