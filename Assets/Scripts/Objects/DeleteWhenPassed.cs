using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenPassed : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.transform.position.z <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
