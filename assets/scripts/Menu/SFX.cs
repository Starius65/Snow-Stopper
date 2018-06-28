using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {

	public AudioClip woosh;
	public AudioClip ding;
	public AudioSource source;
	static string key = "SFX";
	
	void Start () {
		Reload();
	}
	
	void Reload () {
		if (PlayerPrefs.GetFloat(key) < -0.98f) {
			source.volume = 0;
		} else {
			source.volume = (PlayerPrefs.GetFloat(key)+1)/2;
		}
	}

	void Woosh () {
		source.PlayOneShot (woosh);
	}
	void Twinkle () {
		source.PlayOneShot (ding);
	}
}
