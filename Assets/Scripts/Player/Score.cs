using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    int PlayerScore;

    void Start(){
        PlayerScore = 0;
    }

    public void AddScore(int Ammount){
        PlayerScore += Ammount;
        Debug.Log(PlayerScore);
    }


}
