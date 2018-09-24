using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Visualizer;
    [SerializeField]
    private GameObject Cube;
    List<GameObject> objectList = new List<GameObject>();
    private Visualizer Vis;
    private Dictionary<string, float> dictAudio;
    private GameObject Parent;
    [SerializeField]
    private float maxX;

    private Random r = new Random();
    private float elapsed;

    private void Awake()
    {
        Vis = Visualizer.GetComponent<Visualizer>();

        Parent = new GameObject();
        Parent.name = "Walls";

    }

    void Update()
    {
        dictAudio = Vis.getAudioData();
        float rmsValue;
        if (dictAudio.TryGetValue("rms", out rmsValue))
        {
            //Debug.Log(rmsValue);
        }
        elapsed += Time.deltaTime;
        //if (elapsed >= 1f)
        //{
        //    elapsed = elapsed % 1f;
        //    spawnRandomCube();
        //}
        spawnRandomCube();





        }

    void spawnRandomCube()
    {
        GameObject go = Instantiate(Cube, Parent.transform);


        go.transform.position = new Vector3(getRandomX(), -0.22f, 30);


    }

    float getRandomX()
    {
        return (Random.Range(-maxX, maxX));
    }
}
