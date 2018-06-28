using UnityEngine;
using System.Collections;

public class SettingsSlider : MonoBehaviour {

	public GameObject whiteBar;
	public Transform knob;
	public string key;

	void Start() {
		if (!PlayerPrefs.HasKey (key)) {
			PlayerPrefs.SetFloat(key, 1);
			PlayerPrefs.Save();
		}
		knob.localPosition = new Vector3(PlayerPrefs.GetFloat(key), knob.localPosition.y, knob.localPosition.z);
		whiteBar.transform.localPosition = new Vector3 ((knob.localPosition.x / 2)-(0.55f), whiteBar.transform.localPosition.y, whiteBar.transform.localPosition.z);
		whiteBar.transform.localScale = new Vector3 ((knob.localPosition.x)+1, whiteBar.transform.localScale.y, whiteBar.transform.localScale.z);
	}

	void OnTouchStay(Vector3 point) {
		knob.position = new Vector3(Mathf.Clamp(point.x, -1, 1), knob.position.y, knob.position.z);
		whiteBar.transform.localPosition = new Vector3 ((knob.localPosition.x / 2)-(0.55f), whiteBar.transform.localPosition.y, whiteBar.transform.localPosition.z);
		whiteBar.transform.localScale = new Vector3 ((knob.localPosition.x)+1, whiteBar.transform.localScale.y, whiteBar.transform.localScale.z);
	}

	void Save () {
		PlayerPrefs.SetFloat (key, knob.localPosition.x);
		PlayerPrefs.Save();
	}
}
