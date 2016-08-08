using UnityEngine;
using System.Collections;

public class VisibleGain : MonoBehaviour {
	public GameObject controller; 
	public GameObject visibleObject;
	protected Vector3 controllerLocation;
	protected Vector3 visibleObjectLocation; 
	protected Vector3 controllerMovedLocation;

	// Use this for initialization
	void Start () {
		//object is at same place as controller
		visibleObject.transform.position = controller.transform.position;
		controllerLocation = controller.transform.position;
		visibleObjectLocation = controller.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		controllerMovedLocation = controller.transform.position;
		var angle = Vector3.Angle (controllerLocation, controllerMovedLocation);
		//var convertToRadians = angle * Mathf.PI / 180; 
		Vector3 newVector = controllerMovedLocation * Mathf.Cos (angle);
		visibleObject.transform.position = newVector; 
		controllerLocation = controllerMovedLocation; 
	}
}
