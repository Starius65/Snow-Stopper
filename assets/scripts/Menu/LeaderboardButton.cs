using UnityEngine;
using System.Collections;

public class LeaderboardButton : MonoBehaviour {

	public GameObject highscore;
	public float pushedZ;
	Vector3 start;
	Vector3 pushed;
	bool push = false;

	void Start () {
		start = transform.localPosition;
		pushed = new Vector3 (transform.localPosition.x, transform.localPosition.y, pushedZ);
	}
	/* */
	void OnTouchDown () {
		transform.localPosition = pushed;
		push = true;
	}
	void OnTouchUp () {
		if (push) {
			push = false;
		}
		GameObject.Find("Alert").GetComponent<Alert>().Send("Google play services\n currently disabled.", 4);
	}
	void OnTouchExit () {
		transform.localPosition = start;
	}
}