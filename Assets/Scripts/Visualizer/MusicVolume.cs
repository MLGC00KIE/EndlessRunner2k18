using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour {
    [SerializeField]
    AudioSource Music;
	void Update () {
        Music.volume = PlayerPrefs.GetFloat("MusicVolume", 0.60f);
    }
}
