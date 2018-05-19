using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour {

    private StarsDisplay starsDisplay;

    private void Start() {
        starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
    }

    private void AddStars(int amount) {
        starsDisplay.AddStars(amount);
    }
}
