using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    private PlayerMotor m;

    private void Start()
    {
        m = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        // movement
        float xMovement = Input.GetAxisRaw("Mouse X");
        Vector3 HorizontalMov = transform.right * xMovement;
        Vector3 Velocity = (HorizontalMov).normalized * speed;
        m.Move(Velocity);
        // /movement

    }

}