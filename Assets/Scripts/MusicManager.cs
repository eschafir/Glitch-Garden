using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    /**
     * ESTA CLASE DE MUSICMANAGER NO ES UN SINGLETON, YA QUE CORRE POR PRIMERA VEZ EN EL SPLASH, 
     * Y NUNCA MAS VOLVEMOS A ESA PANTALLA, CON LO CUAL NO INTENTA GENERAR OTRAS INSTANCIAS.
     */

    [SerializeField]
    private AudioClip[] levelMusicArray;
    private AudioSource audioSource;
    private string currentAudioClipName = "";

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnLevelLoaded;
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnLevelLoaded(Scene level, LoadSceneMode mode) {
        AudioClip thisLevelMusic = levelMusicArray[level.buildIndex];

        if (IsLoseLevel(level)) {
            audioSource.Stop();
        }

        if (thisLevelMusic && currentAudioClipName != thisLevelMusic.name) {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
            currentAudioClipName = thisLevelMusic.name;
        }
    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }

    bool IsLoseLevel(Scene level) {
        return (level.name == "03b Lose");
    }
}
