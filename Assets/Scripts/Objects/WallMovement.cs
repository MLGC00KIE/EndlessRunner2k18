using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {

    bool isAllowedToMove;
    [SerializeField]
    private float speed;
	
	// Update is called once per frame
	void FixedUpdate () {
        // moves the wall how hard is it to read some code...
        if (isAllowedToMove)
            transform.position += new Vector3(0, 0, -speed * Time.fixedDeltaTime);
    }

    public void CanMove(bool meme)
    {
        isAllowedToMove = meme;
    }
}
