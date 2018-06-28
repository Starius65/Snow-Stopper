using UnityEngine;
using System.Collections;

public class TimePlayed : MonoBehaviour {

	public float secondsPlayed;
	float timeStart;
	float timeEnd;

	void Start (){
		if (PlayerPrefs.HasKey ("timePlayed")) {
			secondsPlayed = PlayerPrefs.GetFloat ("timePlayed");
			}
		}

	void StartTimer () {
		timeStart = Time.time; 
	}
	void EndTimer (){
		timeEnd = Time.time;
		secondsPlayed += ((timeEnd - timeStart)/60/60);
		PlayerPrefs.SetFloat ("timePlayed", secondsPlayed);
		PlayerPrefs.Save ();
		if (secondsPlayed >= 24) {
		//achievements.Get("twentyFour");
		}
	}	
}
