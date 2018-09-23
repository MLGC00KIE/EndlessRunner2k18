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
        SceneManager.LoadScene(LevelName);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
