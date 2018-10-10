using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {

    [SerializeField]
    private float timeBetweenHit;
    [SerializeField]
    GameObject hitEffectObject;
    ParticleSystem hitEffect;
    [SerializeField]
    GameObject deathEffectObject;
    ParticleSystem deathEffect;
    private bool canHit;
    Lives l;
    AudioSource Hit;


    private float elapsed;

    private void Awake()
    {
        Hit = gameObject.GetComponent<AudioSource>();
        l = GetComponent<Lives>();
        hitEffect = hitEffectObject.GetComponent<ParticleSystem>();
        deathEffect = deathEffectObject.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider col)
    {
        // detects if the player is touching an object and deletes its collider to not trigger it again
        if (col.transform.tag == "wall")
        {
            Hit.pitch = Random.Range(0.5f, 1);
            Hit.Play();
            Debug.Log("got hit by " + col.transform.name);
            l.SetHealth(l.GetHealth() - 1);
            Destroy(col.GetComponent<Collider>());
            

            if (l.GetHealth() >= 1)
            {
                hitEffect.Play();
            } else
            {
                deathEffect.Play();
            }


        }
    }


}
