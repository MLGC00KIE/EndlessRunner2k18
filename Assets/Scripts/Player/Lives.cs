using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    [SerializeField]
    private GameObject secondPart;

    [SerializeField]
    private int lives = 2;
	
	// Update is called once per frame
	void Update () {
		if (lives <= 1)
        {
            secondPart.SetActive(false);
        }
        if (lives > 1) {
            secondPart.SetActive(true);
        }
	}

    public void SetHealth(int newHealth)
    {
        lives = newHealth;
    }

    public int GetHealth()
    {
        return lives;
    }

}
