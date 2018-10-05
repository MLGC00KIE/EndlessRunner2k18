using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject Visualizer;
    [SerializeField]
    private GameObject Cube;
    private Visualizer Vis;
    private Dictionary<string, float> dictAudio;
    private GameObject Parent;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float timeBetweenSpawn;

    private float elapsed;

    private void Awake()
    {
        Vis = Visualizer.GetComponent<Visualizer>();

        // make a new empty gameobject to use as the parent for the cubes/walls
        Parent = new GameObject();
        Parent.name = "Walls";

    }

    void Update()
    {

        // WIP spawn cubes on music
        dictAudio = Vis.getAudioData();
        float rmsValue;
        if (dictAudio.TryGetValue("rms", out rmsValue))
        {
            //Debug.Log(rmsValue);
        }
        // ----------------------------------


        // spawn a cube each {timeBetweenSpawn} seconds
        elapsed += Time.deltaTime;
        if (elapsed >= timeBetweenSpawn)
        {
            elapsed = elapsed % timeBetweenSpawn;
            spawnRandomCube();
        }
        spawnRandomCube();





    }

    // spawns a cube on a random x position
    void spawnRandomCube()
    {
        GameObject go = Instantiate(Cube, Parent.transform);


        go.transform.position = new Vector3(getRandomX(), -0.22f, 30);


    }

    // read the function name...
    float getRandomX()
    {
        return (Random.Range(-maxX + 1, maxX));
    }
}
