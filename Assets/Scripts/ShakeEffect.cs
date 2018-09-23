using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float Magnitude = 0.5f;

    Vector3 m_startPos;
    float x, y, z;

    void Start(){
        m_startPos = transform.localPosition;
    }

    private void Update(){
            x = Random.Range(-Magnitude, Magnitude);
            y = Random.Range(-Magnitude, Magnitude);
            z = Random.Range(-Magnitude, Magnitude);

        transform.localPosition = m_startPos + new Vector3(x, y, z);
    }
}