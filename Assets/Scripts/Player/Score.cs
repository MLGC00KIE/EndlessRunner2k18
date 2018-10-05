using UnityEngine;

public class Score : MonoBehaviour {
    int PlayerScore;

    void Start(){
        PlayerScore = 0;
    }

    public void AddScore(int Ammount){
        PlayerScore += Ammount;
    }

    private void Update()
    {

    }


}
