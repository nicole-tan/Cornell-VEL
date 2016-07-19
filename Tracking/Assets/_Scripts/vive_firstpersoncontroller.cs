using UnityEngine;
using System.Collections;

public class vive_firstpersoncontroller : MonoBehaviour {


	SteamVR_TrackedObject trackedObj;
	public GameObject ViveCameraHead;
	public GameObject FPSController;
	public float speed = 3;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Update()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		//トリガーを浅く握る
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
		{
			//Debug.Log("GetTouch Trigger");
			float slowSpeedFactor = 0.5f;
			Vector3 moveDistance = ViveCameraHead.transform.TransformDirection(Vector3.forward);
			Vector3 moveDistance2 = new Vector3(moveDistance.x * Time.deltaTime * speed* slowSpeedFactor, 0, moveDistance.z * Time.deltaTime * speed* slowSpeedFactor);
			FPSController.transform.position += moveDistance2;
		}
		//トリガーを深く握る
		if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
		{
			//Debug.Log("GetPress Trigger");
			Vector3 moveDistance = ViveCameraHead.transform.TransformDirection(Vector3.forward);
			Vector3 moveDistance2 = new Vector3(moveDistance.x * Time.deltaTime * speed, 0, moveDistance.z * Time.deltaTime * speed);
			FPSController.transform.position += moveDistance2;
		}


	}

}