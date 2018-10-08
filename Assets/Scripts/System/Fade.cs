﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    bool Go;
    string Stage;

    public void ChangeLevel(string LevelName){
        Go = true;
        Stage = LevelName;
    } 

	void Update () {
        if (Go){
            Color tmp = gameObject.GetComponent<Image>().color;
            tmp.a += 0.01f;
            gameObject.GetComponent<Image>().color = tmp;
            if (tmp.a >= 1){
                SceneManager.LoadScene(Stage);
            }
        }
    }
}
