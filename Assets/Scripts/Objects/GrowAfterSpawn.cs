using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAfterSpawn : MonoBehaviour
{

    [SerializeField]
    private Vector3 newScale;
    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, newScale, Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // grow in size...
        this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, newScale, Time.deltaTime * speed);
    }
}
