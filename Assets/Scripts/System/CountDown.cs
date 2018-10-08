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
    GameObject Overlay;
    [SerializeField]
    GameObject PauseScreen;

    void FixedUpdate (){
        CountDownTimer -= 1 * Time.deltaTime;
        if (CountDownTimer > 0.5){
            Timer.text = "- " + CountDownTimer.ToString("F0") + " -";
        }else{
            Timer.text = "- GO -";
            try{
            Color tmp = Overlay.GetComponent<Image>().color;
            tmp.a -= 0.05f;
            Overlay.GetComponent<Image>().color = tmp;
            GameObject.Find("Player").GetComponent<PlayerController>().Activate(true);
                if (CountDownTimer < -0.25){
                GameObject.Find("ObjectSpawner").GetComponent<Spawner>().Activate(true);
                    PauseScreen.SetActive(true);
                    Timer.text = "";
                    CountDownTimer = 3.5f;
                    gameObject.SetActive(false);
                //Destroy(this.gameObject);
                }
            }catch{
                //Destroy(this.gameObject);
            }
        }

	}
}
