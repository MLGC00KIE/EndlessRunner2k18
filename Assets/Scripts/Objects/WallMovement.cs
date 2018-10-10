using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {
    bool isAllowedToMove = true;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedMult = 1f;
    [SerializeField]
    private float targetScore = 10;
    [SerializeField]
    private float speedIncrementor = 0.1f;
    Score scoreObject;

    private void Start()
    {
        scoreObject = GameObject.Find("Player").GetComponent<Score>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        // update speed multiplier based on score
        if (scoreObject.GetScore() >= targetScore) {
            speedMult += speedIncrementor;
            targetScore += 10;
        }

        // moves the walls... its in the name
        if (isAllowedToMove)
            transform.position += new Vector3(0, 0, -speed * Time.fixedDeltaTime * speedMult);
    }

    public void CanMove(bool meme)
    {
        isAllowedToMove = meme;
    }
}
