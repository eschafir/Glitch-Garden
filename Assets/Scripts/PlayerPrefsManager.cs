using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume) {
        if (volume > 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        } else {
            Debug.LogError("You are tying to unlock an unexistant level");
        }
    }

    public static bool IsLevelUnlocked(int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
        } else {
            Debug.LogError("Level " + level + " not exist in build order");
            return false;
        }
    }

    public static void SetDifficulty(float diff) {
        if (diff >= 1f && diff <= 8f) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        } else {
            Debug.LogError("Level of difficulty not permited");
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}