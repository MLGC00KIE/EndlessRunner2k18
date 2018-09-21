using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velo = Vector3.zero;
    [SerializeField]
    private float maxX = 3;
    [SerializeField]
    private float tiltAmount = 0.1f;

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
            rb.position += velo;

            if (rb.position.x > maxX)
                rb.position = new Vector3(maxX, -0.2f, 2.8f);

            if (rb.position.x < (maxX * -1))
                rb.position = new Vector3((maxX * -1), -0.2f, 2.8f);
            Tilt();
        }
    }

    void Tilt()
    {
        rb.transform.eulerAngles = new Vector3(0, 0, (rb.position.x * tiltAmount));
    }

}