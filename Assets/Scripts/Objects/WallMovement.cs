using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        // moves the fucking block how hard is it to read some fucking code
        transform.position += new Vector3(0, 0, -speed * Time.fixedDeltaTime);
	}
}
