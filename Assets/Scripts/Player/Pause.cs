using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    bool toggle;
    [SerializeField]
    GameObject GUI;
    [SerializeField]
    AudioSource song;
    [SerializeField]
    Slider MouseSlider;
    [SerializeField]
    Text Mouse;
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        MouseSlider.value = PlayerPrefs.GetFloat("MouseSpeed", 0.2f);
    }

    public void MouseChange(){
        PlayerPrefs.SetFloat("MouseSpeed", MouseSlider.value);
        Mouse.text = "(" + MouseSlider.value.ToString("F2") + ")";
    }

    void FixedUpdate (){
        if (GameObject.Find("Player") == null){
            Destroy(this.gameObject);
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("escape") || Input.GetKeyDown("p")){
            pauseSystem();
        }
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown("r")){
            restart();
        }
    }



    public void restart(){
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void quit(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void pauseSystem(){
        toggle = !toggle;
        GUI.SetActive(toggle);
        if (toggle){
            try{
                song.Pause();
            }catch{
                Debug.Log("song not found..");
            }
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }else{
            try{ 
                song.Play();
            }catch{
                Debug.Log("song not found..");
            }
        Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}

