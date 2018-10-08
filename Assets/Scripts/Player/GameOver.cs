using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    void Start(){
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("ObjectSpawner").GetComponent<Spawner>().Activate(false);
    }

    public void restart(){
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void quit(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

