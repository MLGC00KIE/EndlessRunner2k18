using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {

    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, 0, -speed * Time.fixedDeltaTime);
	}
}
