using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    [SerializeField]
    GameObject PlayerObject;
    void Update() {
        try {
            transform.position = new Vector3(PlayerObject.transform.position.x, transform.position.y, transform.position.z);
        }
        catch
        {

        }
    }
}
