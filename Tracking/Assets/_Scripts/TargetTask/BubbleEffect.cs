using UnityEngine;
using System.Collections;

public class BubbleEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Move ();
	
	}

	IEnumerator Move() {
		while (true) {
			GetComponent<Rigidbody> ().AddForce (Random.insideUnitSphere * 10.0f); 
			yield return new WaitForSeconds (Random.Range (0.5f, 2.5f)); 
		}
	}
}
