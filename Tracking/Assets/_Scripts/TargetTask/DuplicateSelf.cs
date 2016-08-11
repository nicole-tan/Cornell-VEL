using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class DuplicateSelf : MonoBehaviour {
	public GameObject bubble;
	public GameObject plane; 


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			GameObject newObj = (GameObject) Instantiate (bubble, createRandomPos(), Quaternion.identity);
			newObj.tag = "bubble"; 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Creates a Vector3 with random coordinates within the limitations of the plane 
	Vector3 createRandomPos() {
		float randomX = Random.Range (plane.transform.position.x - plane.transform.localScale.x/2, plane.transform.position.x + plane.transform.localScale.x/2);
		float randomY = Random.Range (plane.transform.position.y - plane.transform.localScale.y/2, plane.transform.position.y + plane.transform.localScale.y/2);
		float randomZ = Random.Range (plane.transform.position.z - plane.transform.localScale.z/2, plane.transform.position.z + plane.transform.localScale.z/2);
		return new Vector3 (randomX, randomY, randomZ); 
	} 

}
