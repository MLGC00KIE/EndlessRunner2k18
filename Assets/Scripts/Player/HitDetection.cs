using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "wall")
        {
            Debug.Log("got hit by " + col.transform.name);
            // remove health scripty thingy
        }
    }
}
