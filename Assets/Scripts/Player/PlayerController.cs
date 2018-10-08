using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    bool Active;
    [SerializeField]
    private float sensitivity = 0.2f;
    private PlayerMotor m;

    private void Start()
    {
        m = GetComponent<PlayerMotor>();
    }

    public void Activate(bool State){
        Active = State;
    }

    private void Update()
    {
        if (Active)
        {
            // get mouse input and use it in a Vector3
            float h = sensitivity * Input.GetAxis("Mouse X");
            Vector3 delta = new Vector3(h, 0, 0);
            m.Move(delta);
        }
        else
        {
            Vector3 delta = new Vector3(0, 0, 0);
            m.Move(delta);
        }
    }

    private void FixedUpdate()
    {
        sensitivity = PlayerPrefs.GetFloat("MouseSpeed", 0.2f);
    }
}