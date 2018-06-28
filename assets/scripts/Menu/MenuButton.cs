using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public GameObject menu;
	public float pushedZ;
	Vector3 start;
	Vector3 pushed;
	bool push = false;
	
	void Start () {
		start = transform.localPosition;
		pushed = new Vector3 (transform.localPosition.x, transform.localPosition.y, pushedZ);
	}
	
	void OnTouchDown () {
		transform.localPosition = pushed;
		push = true;
	}
	void OnTouchUp () {
		if (push) {
			push = false;
			transform.localPosition = start;
			menu.SendMessage ("Flip");
		}
	}
	void OnTouchExit () {
		transform.localPosition = start;
	}
}
