using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMovement : MonoBehaviour {
    
    public float GridSpeed;
    private float StartingPos;

    // Use this for initialization
    void Start () {
        StartingPos = transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, 0, -1) * GridSpeed;

		if(transform.position.z <= 3367)
        transform.position = new Vector3(transform.position.x, transform.position.y, StartingPos);
        
	}
}
