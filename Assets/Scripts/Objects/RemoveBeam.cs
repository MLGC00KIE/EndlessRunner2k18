using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBeam : MonoBehaviour {

    [SerializeField]
    private float secondsBeforeDelete;

    private void Awake()
    {
        // destroy the beam after making it look like it spawns the cube
        Destroy(this.gameObject, secondsBeforeDelete);
    }

}
