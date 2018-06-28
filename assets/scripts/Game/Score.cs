using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public EndScore scoreBack;
	int score;
//	int lastScore;
	public TextMesh mesh;
	
	void Update () {
		mesh.text = ""+score;
	}
	
	public void AddScore() {
		score++;
	}
	
	public void GameOver () {
		//lastScore = score;
		scoreBack.SetScore(score);
		if (score > PlayerPrefs.GetInt("Highscore")){
			PlayerPrefs.SetInt("Highscore", score);
			PlayerPrefs.Save();
		}
		GetComponent<Renderer>().enabled = false;
		score = 0;
		CheckScores();
	}

	void CheckScores () {
		/*
		if (lastScore == 0) {
			call.Get("wow");
		}
		if (lastScore == 69) {
			call.Get("noComment");
		}
		if (lastScore >= 100) {
			call.Get("tripleDigits");
		}
		if (lastScore >= 250) {
			call.Get("quarterK");
		}
		if (lastScore == 255) {
			call.Get("Max");
		}
		if (lastScore >= 500) {
			call.Get("addict");
		}
		if (lastScore == 666) {
			call.Get("evilNumber");
		}
		if (lastScore >= 1000) {
			call.Get("0neThousand");
		}
		if (lastScore >= 5000) {
			call.Get("wut");
		}
		if (lastScore > 9000) {
			call.Get("over9000");
		}
		*/
	}
}