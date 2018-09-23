using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public Dropdown Menu;
    private bool fullscreen;

    private void Start()
    {
        Menu.value = PlayerPrefs.GetInt("ResolutionValue", 0);
    }

    public void ResolutionChange(){
        if(PlayerPrefs.GetInt("FullScreenMode", 0) == 0){
            fullscreen = false;
        }else{
            fullscreen = true;
        }

        Debug.Log(Menu.value);

        if (Menu.value == 0)
        Screen.SetResolution(640, 480, fullscreen);
        PlayerPrefs.SetInt("ResolutionValue", 0);

        if (Menu.value == 1)
        Screen.SetResolution(1280, 720, fullscreen);
        PlayerPrefs.SetInt("ResolutionValue", 1);

        if (Menu.value == 2)
        Screen.SetResolution(1920, 1080, fullscreen);
        PlayerPrefs.SetInt("ResolutionValue", 2);
    }
}
