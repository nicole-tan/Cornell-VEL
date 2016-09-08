using UnityEngine;
using System.Collections;

public class GravityOn : MonoBehaviour {

// Update is called once per frame
void Update () {
    EventPress (); 
}

	public void EventPress () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
            Debug.Log("left mouse click!"); 
			GetComponent<Rigidbody> ().useGravity = true;
        }
	}
}
