using UnityEngine;
using System.Collections;
using Valve.VR;

public class AvatarMovement : MonoBehaviour {
    public SteamVR_Camera steamCam; 

	void Update () {
        transform.position = steamCam.head.localPosition;
	}

	public void moveBody () {
		
		
	}

	public void rotateBone() {
		
	}
}
