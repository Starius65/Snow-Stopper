using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GameObject score;
	public GameObject catcher;
	public GameObject slider;
	public GameObject menu;
	public GameObject music;
	public GameObject time;
	public float pushedZ;
	Vector3 start;
	Vector3 pushed;
	bool push;

	void Start () {
		start = transform.localPosition;
		pushed = new Vector3 (transform.localPosition.x, transform.localPosition.y, pushedZ);
		push = false;
	}

	void OnTouchDown () {
		transform.localPosition = pushed;
		push = true;
	}
	void OnTouchUp () {
		if(push) {
			push = false;
			transform.localPosition = start;
			score.GetComponent<Renderer>().enabled = true;
			catcher.GetComponent<Renderer>().enabled = true;
			catcher.GetComponent<Collider>().enabled = true;
			slider.GetComponent<Collider>().enabled = true;
			music.SendMessage("Play");
			menu.SendMessage ("Hide");
			Camera.main.SendMessage ("Begin");
			time.SendMessage ("StartTimer");
		}
	}
	void OnTouchExit () {
		transform.localPosition = start;
	}
}