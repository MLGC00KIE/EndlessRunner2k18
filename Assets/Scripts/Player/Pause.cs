using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    bool toggle;
    public GameObject GUI;
    public Slider MouseSlider;
    public Text Mouse;
    void Start(){
        MouseSlider.value = PlayerPrefs.GetFloat("MouseSpeed", 0.2f);
    }

    public void MouseChange(){
        PlayerPrefs.SetFloat("MouseSpeed", MouseSlider.value);
        Mouse.text = "(" + MouseSlider.value.ToString("F2") + ")";
    }

    void Update () {

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("escape") || Input.GetKeyDown("p")){
            pauseSystem();
        }
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown("r")){
            restart();
        }
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void quit(){
        SceneManager.LoadScene("Menu");
    }

    public void pauseSystem()
    {
        toggle = !toggle;
        GUI.SetActive(toggle);
        if (toggle){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }
}

