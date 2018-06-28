﻿using UnityEngine;
using System.Collections;
 
public class MainMenu : MonoBehaviour {
 
    public GameObject mainHighscore;
    public GameObject deadHighscore;
    public GameObject deadScore;
    public GameObject SFX;
 
    Vector3 rotation;
    bool hide;
    bool dead;
    bool flip;
    Renderer render;
 
    Vector3 hidden;
    Vector3 visible;
 
    void Start () {
        hidden = new Vector3 (transform.position.x, -17, transform.position.z);
        visible = transform.position;
    }
 
    void Update () {
        if (flip) {
            if (rotation.y < 90) {
                deadHighscore.GetComponent<Renderer>().enabled = false;
                deadScore.GetComponent<Renderer>().enabled = false;
                mainHighscore.GetComponent<Renderer>().enabled = true;
            }
            if (rotation.y > 0) {rotation.y -= Time.deltaTime * 700;
            }else{
                rotation.y = 0;
                flip = false;
            }
        }
        if (hide) {
            transform.position = Vector3.Lerp(transform.position, hidden, Time.deltaTime * 7);
        } else {
            transform.position = Vector3.Lerp(transform.position, visible, Time.deltaTime * 9);
        }
        transform.eulerAngles = rotation;
    }
 
    void Hide () {
        //button.Hide();
        SFX.SendMessage("Woosh");
        hide = true;
    }
 
    void Show () {
        //button.Show();
        SFX.SendMessage("Woosh");
        mainHighscore.GetComponent<Renderer>().enabled = false;
        deadScore.GetComponent<Renderer>().enabled = true;
        deadHighscore.GetComponent<Renderer>().enabled = true;
        rotation.y = 180;
        hide = false;
    }
 
    void Flip () {
        SFX.SendMessage("Woosh");
        flip = true;
    }
}