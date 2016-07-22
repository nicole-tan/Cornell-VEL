using UnityEngine;
using System.Collections;

public class HandMovements : SteamVR_ControllerManager {
	public GameObject leftHand;
	public GameObject rightHand;

	void Start () {
		rightHand.transform.position = new Vector3 (-1.8819723f, 1.0269f, 0.10579531f);
	}

	void Update() {
        leftHand.transform.position = new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z);
        rightHand.transform.position = new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z);
        leftHand.transform.rotation = left.transform.rotation;
        rightHand.transform.rotation = right.transform.rotation;

        //y position can't be controller position because that's too low?
        //either that or you have to localize
        //also why does shoulder have attachments, but hands don't?
    }


}
