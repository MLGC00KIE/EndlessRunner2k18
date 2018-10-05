using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour {

    Vector3 boxSize;
    float boxWidth;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private float distanceFromBox;
    [SerializeField]
    private float extraDistanceFromBox;

	// Use this for initialization
	void Start () {
        // get box size
        boxSize = GetComponent<Collider>().bounds.size;
        boxWidth = boxSize.x;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        RaycastHit hit;

        // check for raycasts hitting to add score to player
        Debug.DrawRay((transform.position + new Vector3(-boxWidth, 0, -distanceFromBox)), new Vector3(boxWidth, 0, 0), Color.red);
        if (Physics.Raycast((transform.position + new Vector3(-boxWidth , 0, -distanceFromBox)), new Vector3(boxWidth, 0,0), out hit))
        {
            if (hit.transform.tag == "Player")
            {
                // add score code thingy
            }
        }


        // check for raycasts hitting to add score to player
        Debug.DrawRay((transform.position + new Vector3(-boxWidth / 1.5f, 0, -extraDistanceFromBox)), new Vector3(boxWidth/2, 0, 0), Color.red);
        if (Physics.Raycast((transform.position + new Vector3(-boxWidth / 1.5f, 0, -extraDistanceFromBox)), new Vector3(boxWidth/2, 0, 0), out hit))
        {
            if (hit.transform.tag == "Player")
            {
                // add score thingy for being closer
            }
        }


    }
}
