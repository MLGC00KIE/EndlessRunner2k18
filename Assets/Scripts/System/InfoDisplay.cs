using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour {

    public Text RefreshRate;

    float deltaTime = 0.0f;

    // Update is called once per frame
    void Update ()
    {
        float fps = 1.0f / deltaTime;
        RefreshRate.text = "FPS: " + fps;
    }
}
