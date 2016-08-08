using UnityEngine;
using System.Collections;

public class DotProductGain : MonoBehaviour {
	//controllerObject's previous position
	protected Vector3 time1Loc;
	//controllerObject's current position
	protected Vector3 time2Loc;
	//controllerObject's visible position after change in trajectory
	protected Vector3 visibleTime2;
	public GameObject controllerObject; 
	public GameObject rightObject; 

	// Use this for initialization
	void Start () {
		time1Loc = controllerObject.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Right position is: " + rightObject.transform.position);
		Debug.Log("Left previous position: " + time1Loc); 
		//time2Loc is the current position
		time2Loc = controllerObject.transform.position; 
		Debug.Log("Left current position: " + time2Loc); 
		//angle between the previous location and the current location 
		//dot product -> divide dot by product of magnitudes of vectors -> arccos --> convert to degrees by multiplying by (180/Mathf.PI)
		var angle = Vector3.Angle (time1Loc, time2Loc);
		Debug.Log ("Left angle is: " + angle);
		//position at time 2 must be rotated by angle 
		//controllerObject.transform.eulerAngles = new Vector3 ((controllerObject.transform.eulerAngles.x + angle), (controllerObject.transform.eulerAngles.y + angle), (controllerObject.transform.eulerAngles.z + angle));
		//visibleTime2 = controllerObject.transform.eulerAngles; 

		var convertBack = angle * (Mathf.PI / 180);
		var cosineResult = Mathf.Cos (convertBack);
		//var dotBackwards = cosineResult * angle 

		controllerObject.transform.position = time2Loc * Mathf.Cos (angle);
		Debug.Log ("Left visible position: " + controllerObject.transform.position);
		//controllerObject.transform.position = Quaternion.AngleAxis (angle, Vector3.forward) * Vector3.right; 
		time1Loc = time2Loc; 
	}
}
