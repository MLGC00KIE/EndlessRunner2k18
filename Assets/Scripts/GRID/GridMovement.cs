using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMovement : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObject;

    [SerializeField]
    float GridSpeed = 0.1f;
    private float StartingPos;
    [SerializeField]
    float Distance = 1.05f;

    // Use this for initialization
    void Start () {
        StartingPos = transform.position.z; //Start positie is begin positie van object.
	}

	void FixedUpdate () {
        transform.position += new Vector3(0, 0, -1) * GridSpeed; //Laat grid bewegen

        if (transform.position.z <= -Distance + StartingPos) //Als hij voorbij punt is teleporteer terug.
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, StartingPos);
        }

        /*if (GameScore == OldScore + 10) //als er 10 meer punten zijn
        {
            OldScore = GameScore; //verander requirements
            GridSpeed += 0.01f; //voeg snelheid toe
        }*/


        if (PlayerObject == null)//als speler niet bestaat
        {
            GridSpeed = 0.01f; //word langzaam
        }
	}
}
