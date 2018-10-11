using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    bool Go;
    string Stage;
    bool FadedIn;

    public void FadeToLevel(string LevelName){
        Go = true;
        Stage = LevelName;
    } 

	void Update () {
        if (!FadedIn)
        {
            Color tmp = gameObject.GetComponent<Image>().color;
            tmp.a = 0 * Time.unscaledDeltaTime;
            gameObject.GetComponent<Image>().color = tmp;
            if (tmp.a <= 0)
                FadedIn = true;
        }
        if (Go){
            Color tmp = gameObject.GetComponent<Image>().color;
            tmp.a += 1 * Time.unscaledDeltaTime;
            gameObject.GetComponent<Image>().color = tmp;
            if (tmp.a >= 1)
            {
                FadedIn = false;
                Go = false;
                SceneManager.LoadScene(Stage);
            }
        }
    }
}
