using UnityEngine;

public class Score : MonoBehaviour {
    int PlayerScore;

    void Start(){
        PlayerScore = 0;
        Debug.Log("memes");
    }

    public void AddScore(int Ammount){
        PlayerScore += Ammount;
        Debug.Log(PlayerScore);
    }

    private void Update()
    {
        Debug.Log(PlayerScore);
    }


}
