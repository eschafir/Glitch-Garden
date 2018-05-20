using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

    // Use this for initialization
    void Start() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsManager.GetMasterVolume();
    }

}
