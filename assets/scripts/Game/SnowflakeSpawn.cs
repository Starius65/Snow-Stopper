using UnityEngine;
using System.Collections;

public class SnowflakeSpawn : MonoBehaviour {
		
	public Score score;
	public GameObject catcher;
	public GameObject slider;
	public GameObject menu;
	public GameObject highscore;
	public GameObject highscoreBack;
	public GameObject SFX;
	public GameObject music;
	public GameObject time;
	float timePassed;
	float height;
	float width;
	bool gameOver;
	string poolObject;

	void Start () {
		poolObject = "Snowflake";
		height = Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
		gameOver = true;
	}

	void Update () {
		if (!gameOver) {
			if(timePassed >= 0.4) {
				PoolManager.Spawn(poolObject).transform.position = new Vector3(Random.Range(-width+.06f,width-.06f), height+5, -10);
				timePassed = 0;
			}
			timePassed += Time.deltaTime;
		}
	}

	void GroundCollide () {
		if (!gameOver) {
			score.GameOver();
			catcher.GetComponent<Renderer>().enabled = false;
			catcher.GetComponent<Collider>().enabled = false;
			slider.GetComponent<Collider>().enabled = false;
			catcher.transform.position = new Vector3(0, -7.8f, -9.9f);
			gameOver = true;
			music.SendMessage("Stop");
			highscore.SendMessage("UpdateText");
			menu.SendMessage("Show");
			time.SendMessage("EndTimer");
		}
	}

	void CatcherCollide () {
		SFX.SendMessage("Twinkle");
		if (!gameOver) {
			score.AddScore();
		}
	}

	void Begin () {
		gameOver = false;
		foreach (GameObject snowflake in GameObject.FindGameObjectsWithTag("Respawn")) {
			PoolManager.Despawn (snowflake);
		}
	}
}
