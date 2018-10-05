using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    [SerializeField]
    private GameObject secondPart;
    [SerializeField]
    private GameObject GameOverUI;

    [SerializeField]
    private int lives = 2;
	
	// Update is called once per frame
	void Update () {
        // use health to determine ship size
		if (lives <= 1)
        {
            StartCoroutine(HealthTimer());
            secondPart.SetActive(false);
        }
        if (lives > 1) {
            secondPart.SetActive(true);
        }
        if(lives == 0){
            GameOverUI.SetActive(true);
            Destroy(this.gameObject);
        }
	}
    

    IEnumerator HealthTimer(){
        yield return new WaitForSeconds(5);
        lives = 2;
    }

    // set health of player
    public void SetHealth(int newHealth){
        lives = newHealth;
    }

    // returns health of player
    public int GetHealth(){
        return lives;
    }

}
