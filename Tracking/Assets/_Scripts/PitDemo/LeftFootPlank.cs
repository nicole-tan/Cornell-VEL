using UnityEngine;
using System.Collections;

public class LeftFootPlank : MonoBehaviour {
	public GameObject leftModel; 

	// Use this for initialization
	void Start () {
		//leftModel.SetActive (false); 

		transform.position = new Vector3 (leftModel.transform.position.x, leftModel.transform.position.y - 0.2f, leftModel.transform.position.z + 0.5f);  
		transform.eulerAngles = new Vector3 (90, 180, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
