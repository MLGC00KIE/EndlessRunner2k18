using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMovement : MonoBehaviour {
    
    public float GridSpeed = 0.1f;
    private float StartingPos;
    public float Distance = 1.05f;

    // Use this for initialization
    void Start () {
        StartingPos = transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, 0, -1) * GridSpeed;

		if(transform.position.z <= -Distance + StartingPos)
        transform.position = new Vector3(transform.position.x, transform.position.y, StartingPos);
        
	}
}
