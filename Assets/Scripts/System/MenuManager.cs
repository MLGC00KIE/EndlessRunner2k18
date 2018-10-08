using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Text Version;
    private void Awake() {
        if (Version != null) { 
            Version.text = "Ver: " + Application.version;
        }
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("vSync", 1);
    }

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
