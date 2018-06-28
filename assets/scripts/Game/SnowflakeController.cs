using UnityEngine;
using System.Collections;

public class SnowflakeController : MonoBehaviour {
	
	public bool active;
	public GameObject manager;

	void Start () {
		manager = Camera.main.gameObject;
	}

	void Update () {
		transform.Translate (Vector3.down * 8 * Time.deltaTime);
		transform.Rotate (Vector3.up * 90 * Time.deltaTime);
	}

	void OnTriggerEnter (Collider col) {
		if (col.name == "Ground") {
			manager.gameObject.SendMessage("GroundCollide");
			PoolManager.Despawn(gameObject);
		}
		if (col.name == "Catcher") {
			manager.gameObject.SendMessage("CatcherCollide");
			PoolManager.Despawn(gameObject);
		}
	}
}