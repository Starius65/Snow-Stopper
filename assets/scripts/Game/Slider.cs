using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {

	public Transform knob;

	void OnTouchStay(Vector3 point) {
		knob.position = new Vector3(point.x, knob.position.y, knob.position.z);
	}
}
