using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    GameObject[] blocks;
    bool toggle;
    [SerializeField]
    GameObject GUI;
    [SerializeField]
    AudioSource song;
    [SerializeField]
    Slider MouseSlider;
    [SerializeField]
    Text Mouse;
    [SerializeField]
    GameObject CountDown;
    bool isFirstTime = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MouseSlider.value = PlayerPrefs.GetFloat("MouseSpeed", 0.2f);

    }
    public void MouseChange()
    {
        PlayerPrefs.SetFloat("MouseSpeed", MouseSlider.value);
        Mouse.text = "(" + MouseSlider.value.ToString("F2") + ")";
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus && !toggle)
            pauseSystem();
    }

    public void ContinueSong()
    {
        if(!song.isPlaying)
        {
            if (!isFirstTime)
                song.UnPause();
            else if (isFirstTime)
            {
                song.Play();
                isFirstTime = false;
            }        
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
        {
            pauseSystem();
        }
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown("r"))
        {
            restart();
        }
    }

    void FixedUpdate()
    {
        if (GameObject.Find("Player") == null)
        {
            Destroy(this.gameObject);
        }
    }


    public void PauseBlocks(bool trueOrFalse)
    {
        blocks = GameObject.FindGameObjectsWithTag("wall");
        foreach (GameObject go in blocks)
        {
            go.GetComponent<WallMovement>().CanMove(trueOrFalse);
        }

    }

    public void restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();

        try { GameObject.Find("SceneFader").GetComponent<FadeScript>().FadeToLevel(scene.name); }
        catch { SceneManager.LoadScene(scene.name); }
    }

    public void quit()
    {
        Time.timeScale = 1;

        try { GameObject.Find("SceneFader").GetComponent<FadeScript>().FadeToLevel("Menu"); }
        catch { SceneManager.LoadScene("Menu"); }
    }

    public void pauseSystem()
    {
        toggle = !toggle;
        GUI.SetActive(toggle);
        if (toggle)
        {
            try
            {
                song.Pause();

            }
            catch
            {
                Debug.Log("Error: song not found..");
            }
            GameObject.Find("Player").GetComponent<PlayerController>().Activate(false);
            GameObject.Find("ObjectSpawner").GetComponent<Spawner>().Activate(false);
            song.Pause();
            PauseBlocks(true);
            try
            {
                GameObject.Find("Console").GetComponent<Console>().Logger("<color=red>Mouse is free!\n</color>");
            }
            catch { }
                Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            try
            {
                gameObject.SetActive(false);
                CountDown.SetActive(true);
            }
            catch
            {
                try
                {
                    GameObject.Find("Console").GetComponent<Console>().Logger("<color=red>Big error, Cannot find song?!\n</color>");
                }
                catch { }
            }

            try
            {
                GameObject.Find("Console").GetComponent<Console>().Logger("<color=red>cursor is locked.\n</color>");
            }
            catch { }
            Cursor.lockState = CursorLockMode.Locked;
            //Time.timeScale = 1;
        }
    }

}

