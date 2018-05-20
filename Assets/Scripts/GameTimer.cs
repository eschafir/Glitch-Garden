using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100f;

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
            StopSpawnAndKillAllEnemies();
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

    void StopSpawnAndKillAllEnemies() {
        IdleAllDefenders();
        KillAllEnemies();
        DisableAllSpawners();
    }

    void IdleAllDefenders() {
        Defender[] defenders = GameObject.FindObjectsOfType<Defender>();

        foreach (Defender def in defenders) {
            if (def.gameObject.GetComponent<Animator>().GetBool("isAttacking")) {
                def.gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
            }
        }
    }

    void DisableAllSpawners() {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
            spawner.gameObject.SetActive(false);
        }
    }

    void KillAllEnemies() {
        Attacker[] enemies = GameObject.FindObjectsOfType<Attacker>();
        foreach (Attacker att in enemies) {
            Destroy(att.gameObject);
        }
    }
}
