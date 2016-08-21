using UnityEngine;
using System.Collections;

public class PopBubble : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "bubble" && col.gameObject != null) {
			Destroy (col.gameObject);
		}
	}
}
