using UnityEngine;
using System.Collections;

public class AvatarMovement: SteamVR_Camera {
    public GameObject hmd;

    void Update () {
		transform.position = hmd.transform.position; 
	}

	public void moveBody () {
		
		
	}

	public void rotateBone() {
		
	}
}
