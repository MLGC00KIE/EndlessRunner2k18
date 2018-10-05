using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {

    [SerializeField]
    private float timeBetweenHit;

    private bool canHit;
    Lives l;

    private float elapsed;

    private void Awake()
    {
        l = GetComponent<Lives>();
    }

    private void OnCollisionEnter(Collision col)
    {
        // detects if the player is touching an object and deletes it
        if (col.transform.tag == "wall")
        {
            Debug.Log("got hit by " + col.transform.name);
            l.SetHealth(l.GetHealth() - 1);
            Destroy(col.collider);

        }
    }


}
