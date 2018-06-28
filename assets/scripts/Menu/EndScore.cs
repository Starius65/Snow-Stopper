using UnityEngine;
using System.Collections;

public class EndScore : MonoBehaviour {

	public TextMesh text;
	
	public void SetScore (int score) {
		text.text = "" + score;
	}
}
