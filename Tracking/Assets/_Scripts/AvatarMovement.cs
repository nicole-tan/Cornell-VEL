using UnityEngine;
using System.Collections;
using Valve.VR;

public class AvatarMovement : MonoBehaviour {
    public SteamVR_Camera steamCam;
    public GameObject neck;

	void Update () {
        neck.transform.position = steamCam.head.localPosition;
	}

	public void moveBody () {
		
		
	}

	public void rotateBone() {
		
	}
}
