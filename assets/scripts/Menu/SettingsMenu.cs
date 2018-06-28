using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

	bool hide;
	bool dead;

	Vector3 hidden;
	Vector3 visible;

	public GameObject SFX;
	
	void Start () {
		hide = true;
		hidden = transform.position;
		visible = new Vector3 (0, transform.position.y, transform.position.z);
	}
	
	void Update () {
		if (hide) {
			transform.position = Vector3.Lerp(transform.position, hidden, Time.deltaTime * 7);
		} else {
			transform.position = Vector3.Lerp(transform.position, visible, Time.deltaTime * 9);
		}
	}
	
	void SetHidden (bool blarg) {
		SFX.SendMessage("Woosh");
		hide = blarg;
	}
}