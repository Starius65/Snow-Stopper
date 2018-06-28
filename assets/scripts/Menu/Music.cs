using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioSource source;
	static string key = "Music";
	
	void Start () {
		Reload();
	}
	
	void Reload () {
		if (PlayerPrefs.GetFloat(key) < -0.98f) {
			source.volume = 0;
			Debug.Log("Seccessu");
		} else {
			source.volume = (PlayerPrefs.GetFloat(key)+1)/2;
		}
	}
	
	void Play () {
		source.PlayDelayed(1);
	}
	void Stop () {
		source.Stop();
	}
}
