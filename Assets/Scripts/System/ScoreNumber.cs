using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNumber : MonoBehaviour {
    public Text ScoreUI;

    void Start(){
        ScoreUI.text = "- SCORE: 0 -";
    }

    public void UpdateScore(int Value){
        ScoreUI.text = "- SCORE: " + Value+ " -";
    }
}
