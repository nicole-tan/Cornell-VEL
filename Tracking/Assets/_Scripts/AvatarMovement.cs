using UnityEngine;
using System.Collections;

public class AvatarMovement : SteamVR_Camera {

	void Update () {
		transform.position = head.transform.position; 
	}

	public void moveBody () {
		
		
	}

	public void rotateBone() {
		
	}
}
