using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaylist : MonoBehaviour {

    [SerializeField]
    private Object[] music;
    [SerializeField]
    private AudioSource src;
    private float timePlayed;

    private void Awake()
    {
        src.clip = music[Random.Range(0, music.Length)] as AudioClip;
    }

    private void Update()
    {
        if (src.isPlaying)
        {
            timePlayed += Time.deltaTime;
            if (timePlayed >= src.clip.length)
            {
                playRandomMusic();
                timePlayed = 0;
            }
        }
        //if (!src.isPlaying && allowedToPlay)
        //    playRandomMusic();
    }

    private void playRandomMusic()
    {
        src.clip = music[Random.Range(0, music.Length)] as AudioClip;
        src.Play();
    }

}
