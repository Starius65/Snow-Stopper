using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour {
	
	Renderer render;
	TextMesh text;
	float time;

	void Start()
	{
		render = GetComponent<Renderer>();
		text = GetComponent<TextMesh>();
	}

	public void Send(string message, float displayTime)
	{
		text.text = message;
		render.enabled = true;
		time = displayTime;
	}

	void Update()
	{
		if(render.enabled)
		{
			time -= Time.deltaTime;
			if (time <= 0)
			{
				render.enabled = false;
			}
		}
	}
}
