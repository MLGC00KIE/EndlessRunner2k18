using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velo = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    public void Move(Vector3 Velocity)
    {
        velo = Velocity;
    }

    void DoMovement()
    {
        if (velo != Vector3.zero)
        {
            rb.MovePosition(rb.position + velo * Time.fixedDeltaTime);
        }
    }
}