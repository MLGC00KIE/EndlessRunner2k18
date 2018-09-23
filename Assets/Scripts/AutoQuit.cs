using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoQuit : MonoBehaviour {
    private float timer;
    private bool OHNO;
    public Text warn;

    // Update is called once per frame
    void Update() {
        timer += 1 * Time.deltaTime;

        if (timer >= 3)
        {
            Application.Quit();
            Debug.Log("If you ever see this, something went terribly wrong! It won't stop!");
            OHNO = true;
        }
        if (OHNO)
        {
            if (timer >= 2)
            {
                warn.text = "";
            }
            if(timer <= 1.5f)
            {
                warn.text = "FAILED TO QUIT APPLICATION!!\nIF YOU SEE THIS SOMETHING\nWENT TERRIBLY WRONG!!";
            }
            if(timer >= 2.5f)
            {
                Application.Quit();
                Debug.Log("I still cannot quit pls send help!");
                timer = 0;
            }
        }

	}
}
