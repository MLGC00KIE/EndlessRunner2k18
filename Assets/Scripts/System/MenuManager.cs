using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void Activate(GameObject Object)
    {
        Object.SetActive(true);
    }

    public void Deactivate(GameObject Object)
    {
        Object.SetActive(false);
    }

    public void ChangeLevel(string LevelName)
    {
        if (Application.CanStreamedLevelBeLoaded(LevelName)){
            SceneManager.LoadScene(LevelName);
            }else{
            SceneManager.LoadScene("error");
        }
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
