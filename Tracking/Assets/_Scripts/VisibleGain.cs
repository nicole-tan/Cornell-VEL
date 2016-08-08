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
		//Find controller location 
		controllerLocation = controller.transform.position;
		visibleObjectLocation = controller.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		//Find controller second position
		controllerMovedLocation = controller.transform.position;
		//Find angle between time1 and time2 
		var angle = Vector3.Angle (controllerLocation, controllerMovedLocation);
		//var convertToRadians = angle * Mathf.PI / 180; 

		//Find newVector from the second location and the given angle using cosine
		Vector3 newVector = controllerMovedLocation * Mathf.Cos (angle);

		//Find angle from the first time to the newVector 
		var newAngle = Vector3.Angle(controllerLocation, newVector);
		//Create a new vector by applying this newAngle to the visibleObject's current location 
		Vector3 visVector = visibleObjectLocation * Mathf.Cos (newAngle);
		//transform the visible object to the location of the newest vecotr
		visibleObject.transform.position = visVector; 
		//set the new visible location to the current display position
		visibleObjectLocation = visVector; 
		//set the current controller location to location #2 
		controllerLocation = controllerMovedLocation; 


		//controllerMovedLocation = controller.transform.position; 
		//var angle = Vector3.Angle(controllerLocation, controllerMovedLocation);
		//Vector3 newVector = controllerMovedLocation * Mathf.Cos(angle);
		//visibleObject.transform.position = newVector;
		//controllerLocation = controllerMovedLocation 
	}
}
