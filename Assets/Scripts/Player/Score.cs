using UnityEngine;

public class Score : MonoBehaviour {
    int PlayerScore;

    void Start(){
        PlayerScore = 0;
    }

    public void AddScore(int Amount){
        PlayerScore += Amount;
        GameObject.Find("ScoreUI").GetComponent<ScoreNumber>().UpdateScore(PlayerScore);
    }

    private void Update()
    {

    }


}
