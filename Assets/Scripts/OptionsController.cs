using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider, difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

    void Start() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    void Update() {
        musicManager.ChangeVolume(volumeSlider.value);
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01a Start");
    }

    public void DefaultSettings() {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2f;
    }
}
