using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownFix : MonoBehaviour {
    bool Loaded;

	void Update () {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (!Loaded)
            {
                SceneManager.LoadScene("Game");
                Loaded = true;
            }
        }
        else
        {
            Loaded = false;
        }

	}
}
