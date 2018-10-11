using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    float CountDownTimer = 3.5f;
    [SerializeField]
    Text Timer;
    [SerializeField]
    GameObject PauseScreen;
    Color Default;
    GameObject Player;

    private void Start()
    {
        Default = Timer.color;
        CountDownTimer = 3.5f;
        Player = GameObject.Find("Player");
    }
    

    void Update (){
        CountDownTimer -= 1 * Time.unscaledDeltaTime;
        if (CountDownTimer > 0.5){
            Timer.text = "- " + CountDownTimer.ToString("F0") + " -";
        }else{
            Timer.text = "- GO -";
            Timer.color -= new Color(0, 0, 0, 1f) * Time.unscaledDeltaTime;
            try
            {
                Player.GetComponent<PlayerController>().Activate(true);
                PauseScreen.GetComponent<Pause>().ContinueSong();
                GameObject.Find("ObjectSpawner").GetComponent<Spawner>().Activate(true);
                Time.timeScale = 1;
                if (CountDownTimer < -0.25){
                    GameObject.Find("Console").GetComponent<Console>().Logger("<color=orange>PlayerMovement: <color=aqua>true</color>\nSong: <color=aqua>true</color>\nCubeSpawning: <color=aqua>true</color>\nTimeScale: <color=aqua>1</color></color>\n");

                    PauseScreen.SetActive(true);
                    PauseScreen.GetComponent<Pause>().PauseBlocks(true);
                    Timer.text = "";
                    Timer.color = Default;
                    CountDownTimer = 3.5f;
                    gameObject.SetActive(false);

                //Destroy(this.gameObject);
                }
            }catch{
                try
                {
                    GameObject.Find("Console").GetComponent<Console>().Logger("<color=red>Big error, Countdown did not continue the game!\n</color>");
                } catch {

                }
            }
        }

	}

}
