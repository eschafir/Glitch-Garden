using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float delay;
    private Fading fading;

    private void Start() {
        fading = GetComponent<Fading>();
        if (ActualScene() == 0) {
            Invoke("MainMenu", delay);
        }
    }

    public void LoadLevel(string name) {
        StartCoroutine(FadeAndLoadLevel(name));
    }

    public static int ActualScene() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel() {
        StartCoroutine(FadeAndLoadNextLevel());
    }

    public void MainMenu() {
        StartCoroutine(FadeAndLoadLevel("01a Start"));
    }

    public void Win() {
        SceneManager.LoadScene("03a Win");
    }

    public void Lose() {
        SceneManager.LoadScene("03b Lose");
    }

    IEnumerator FadeAndLoadLevel(string name) {
        float time = fading.BeginFade(1);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
    }

    IEnumerator FadeAndLoadNextLevel() {
        float time = fading.BeginFade(1);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(ActualScene() + 1);
    }
}