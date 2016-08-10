using UnityEngine;
using System.Collections;

public class RightFootTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, transform.position.y - 1.0f, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y - 1.0f, transform.position.z);
	
	}
}
