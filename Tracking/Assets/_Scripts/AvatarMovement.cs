using UnityEngine;
using System.Collections;

public class AvatarMovement : ViveController {

	void Update () {
		transform.position = currCamera.transform.position; 
	}

	public void moveBody () {
		
		
	}

	public void rotateBone() {
		
	}
}
