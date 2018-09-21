using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float sensitivity = 0.5f;
    private PlayerMotor m;

    private void Start()
    {
        m = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float h = sensitivity * Input.GetAxis("Mouse X");
        Vector3 delta = new Vector3(h, 0, 0);
        m.Move(delta);
    }
}