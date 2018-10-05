using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenPassed : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {

        /***
     *                                         __          __      __                                                  __           
     *                                        |  \        |  \    |  \                                                |  \          
     *      ______    ______    ______    ____| $$       _| $$_   | $$____    ______          _______   ______    ____| $$  ______  
     *     /      \  /      \  |      \  /      $$      |   $$ \  | $$    \  /      \        /       \ /      \  /      $$ /      \ 
     *    |  $$$$$$\|  $$$$$$\  \$$$$$$\|  $$$$$$$       \$$$$$$  | $$$$$$$\|  $$$$$$\      |  $$$$$$$|  $$$$$$\|  $$$$$$$|  $$$$$$\
     *    | $$   \$$| $$    $$ /      $$| $$  | $$        | $$ __ | $$  | $$| $$    $$      | $$      | $$  | $$| $$  | $$| $$    $$
     *    | $$      | $$$$$$$$|  $$$$$$$| $$__| $$        | $$|  \| $$  | $$| $$$$$$$$      | $$_____ | $$__/ $$| $$__| $$| $$$$$$$$
     *    | $$       \$$     \ \$$    $$ \$$    $$         \$$  $$| $$  | $$ \$$     \       \$$     \ \$$    $$ \$$    $$ \$$     \
     *     \$$        \$$$$$$$  \$$$$$$$  \$$$$$$$          \$$$$  \$$   \$$  \$$$$$$$        \$$$$$$$  \$$$$$$   \$$$$$$$  \$$$$$$$
     *                                                                                                                              
     *                                                                                                                              
     *                                                                                                                              
     */

        // deletes the cube once it passes a certain z position
        if (this.transform.position.z <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
