using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class DuplicateSelf : MonoBehaviour {
	public GameObject bubble;
	public GameObject plane; 
	public float lifetime = 5.0f; 
	public int numBubbles = 5; 


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			GameObject newObj = (GameObject) Instantiate (bubble, createRandomPos(), Quaternion.identity);
			newObj.tag = "bubble"; 
			newObj.GetComponent<Rigidbody> ().useGravity = false; 
			//newObj.transform.localScale = createRandomSize ();
			Destroy (newObj, lifetime);

			InvokeRepeating ("createNewBubbles", 2, 5);
		}
	}


	//Creates a Vector3 with random coordinates within the limitations of the plane 
	Vector3 createRandomPos() {
		float randomX = Random.Range (plane.transform.position.x - plane.transform.localScale.x/2, plane.transform.position.x + plane.transform.localScale.x/2);
		float randomY = Random.Range (plane.transform.position.y - plane.transform.localScale.y/2, plane.transform.position.y + plane.transform.localScale.y/2);
		float randomZ = Random.Range (plane.transform.position.z - plane.transform.localScale.z/2, plane.transform.position.z + plane.transform.localScale.z/2);
		return new Vector3 (randomX, randomY, randomZ); 
	} 

	Vector3 createRandomSize() {
		float randomSize = Random.Range (0.09f, 0.60f); 
		return new Vector3 (randomSize, randomSize, randomSize); 
	}

	void createNewBubbles() {
		for (var i = 0; i < numBubbles; i++) {
			GameObject newObj = (GameObject) Instantiate (bubble, createRandomPos(), Quaternion.identity);
			newObj.tag = "bubble"; 
			newObj.GetComponent<Rigidbody> ().useGravity = false; 
			Destroy (newObj, lifetime);
		} 
	}

}
