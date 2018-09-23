using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Visualizer;
    private Visualizer Vis;
    private Dictionary<string, float> dictAudio;

    private void Awake()
    {
        Vis = Visualizer.GetComponent<Visualizer>();

    }

    void Update()
    {
        dictAudio = Vis.getAudioData();
        float rmsValue;
        if (dictAudio.TryGetValue("rms", out rmsValue))
        {
            Debug.Log(rmsValue);
        }

        
        
    }
}
