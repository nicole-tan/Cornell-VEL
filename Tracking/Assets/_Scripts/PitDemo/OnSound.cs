using UnityEngine;
using System.Collections;

public class OnSound : MonoBehaviour {


public AudioSource audioSource;
public AudioClip audioClip;

public void playClip() {
    audioSource.clip = audioClip;
    audioSource.Play();
}

// Update is called once per frame
void Update () {
    EventPress (); 
}

public void EventPress () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Debug.Log ("left mouse click!"); 
			GetComponent<Rigidbody> ().useGravity = true;
            audioSource.Play();
        }
	}
}
