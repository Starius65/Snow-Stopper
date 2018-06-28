using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

	public GameObject settingsMenu;
	public bool hide;
	public float pushedZ;
	public GameObject slider;
	public GameObject slider2;
	public GameObject source1;
	public GameObject source2;
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
			if (hide) {
				slider.SendMessage ("Save");
				slider2.SendMessage ("Save");
				source1.SendMessage("Reload");
				source2.SendMessage("Reload");
			}
			transform.localPosition = start;
			settingsMenu.SendMessage ("SetHidden", hide);
			}
	}
	void OnTouchExit () {
		transform.localPosition = start;
	}
}