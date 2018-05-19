using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 10f;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

    // Use this for initialization
    void Start() {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        FindAndSetWinLabel();
    }

    // Update is called once per frame
    void Update() {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if (timeIsUp && !isEndOfLevel) {
            PopWinLabel();
        }
    }

    private void PopWinLabel() {
        winLabel.SetActive(true);
        audioSource.loop = false;
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void LoadNextLevel() {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadNextLevel();
    }

    void FindAndSetWinLabel() {
        winLabel = GameObject.Find("You Win");
        if (!winLabel) {
            Debug.LogWarning("Please create a You Win Label");
        } else {
            winLabel.SetActive(false);
        }

    }
}
