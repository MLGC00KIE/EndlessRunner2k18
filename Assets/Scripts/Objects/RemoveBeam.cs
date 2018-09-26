using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBeam : MonoBehaviour {

    [SerializeField]
    private float secondsBeforeDelete;

    private void Awake()
    {
        Destroy(this.gameObject, secondsBeforeDelete);
    }

}
