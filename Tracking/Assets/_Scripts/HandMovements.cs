using UnityEngine;
using System.Collections;

public class HandMovements : SteamVR_ControllerManager {

	void Update() {
		transform.position = left.transform.position; 
	}


}
