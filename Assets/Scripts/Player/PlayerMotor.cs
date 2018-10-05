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
    [SerializeField]
    private float tiltSpeed;
    [SerializeField]
    private float movementLerpSpeed;

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
        // sets velo to the value PlayerController passed in the function argument
        velo = Velocity;
    }

    void DoMovement()
    {
        // move the character
        if (velo != Vector3.zero)
        {
            rb.position += velo;

            if (rb.position.x > maxX)
                rb.position = new Vector3(maxX, -0.2f, 2.8f);

            if (rb.position.x < (maxX * -1))
                rb.position = new Vector3((maxX * -1), -0.2f, 2.8f);
            //Tilt();
        }
    }

    //void Tilt()
    //{
    //    //rb.transform.eulerAngles = new Vector3(0, 0, (velo.x * tiltAmount));
    //    rb.transform.eulerAngles = Vector3.Lerp(new Vector3(0,0,transform.rotation.y), new Vector3(0, 0, (velo.x * tiltAmount)), tiltSpeed);
    //}

}