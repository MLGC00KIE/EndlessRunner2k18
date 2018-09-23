using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowFPS : MonoBehaviour
{
    float deltaTime = 0.0f;
    public Text Text;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        Text.text = fps.ToString("F0") + "FPS";
    }
    
}