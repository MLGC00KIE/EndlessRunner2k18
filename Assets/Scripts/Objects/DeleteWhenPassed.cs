using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenPassed : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {

        /***
 *                      .___       
 *      ____   ____   __| _/ ____  
 *    _/ ___\ /  _ \ / __ |_/ __ \ 
 *    \  \___(  <_> ) /_/ |\  ___/ 
 *     \___  >\____/\____ | \___  >
 *         \/            \/     \/ 
 */
        // read the fucking class name lmao
        if (this.transform.position.z <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
