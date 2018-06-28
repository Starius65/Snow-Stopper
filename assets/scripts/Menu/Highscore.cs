using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class Highscore : MonoBehaviour {
	
	public TextMesh text;
	public TextMesh textBack;
	int score;
	static string leaderboardID;

	void Start () {
		leaderboardID = "snowStopper";

		if(PlayerPrefs.HasKey("Highscore")){
			score = PlayerPrefs.GetInt("Highscore");
			text.text = ""+score;
			textBack.text = ""+score;
		}else{
			PlayerPrefs.SetInt("Highscore", 0);
		}
		Social.localUser.Authenticate (ProcessAuthentication);
	}

	void UpdateText () {
		if(PlayerPrefs.HasKey("Highscore")){
			score = PlayerPrefs.GetInt("Highscore");
			text.text = ""+score;
			textBack.text = ""+score;
		}else{
			PlayerPrefs.SetInt("Highscore", 0);
		}
		//report scores
	}

	void ProcessAuthentication (bool success) {
		if (success) {
			ILeaderboard leaderboard = Social.CreateLeaderboard();
			leaderboard.id = leaderboardID;
			leaderboard.LoadScores(yes => {
				if (yes) {
					IScore[] scores = leaderboard.scores;
					foreach (IScore iscore in scores) {
						int value = (int)iscore.value;
						Debug.Log(value);
						if (iscore.userID == Social.localUser.id) {
							if (value > score) {
								PlayerPrefs.SetInt("Highscore", value);
								UpdateText ();
							}
							if (value < score) {
								//report score
							}
						}
					}
				}
				else
					Debug.Log ("No scores loaded");
			});
		}
	}
}
