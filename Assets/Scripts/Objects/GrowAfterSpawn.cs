using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAfterSpawn : MonoBehaviour
{

    [SerializeField]
    private Vector3 newScale;
    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        // grow in size...
        this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, newScale, Time.deltaTime * speed);
    }
}
