using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunMovement : MonoBehaviour {
    [SerializeField]
    float Speed = 0.1f;
    private float StartingPos;
    //[SerializeField]
    //float Distance = 1.05f;
    private float DefaultScale;
    	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, 0.01f, 0) * Speed;//beweeg
        transform.localScale += new Vector3(0, 0.1F, 0) / 700 * Speed;//groei

        if(transform.position.y >= 14)//als vorbij punt reset.
        {
            transform.position = new Vector3(transform.position.x, 1.8f, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x, 0.001f, transform.localScale.z);
        }
	}
}
