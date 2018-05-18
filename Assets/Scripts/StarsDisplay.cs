using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class StarsDisplay : MonoBehaviour {

    private int stars = 0;
    private Text starsText;

    // Use this for initialization
    void Start() {
        starsText = GetComponent<Text>();
        starsText.text = stars.ToString();
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddStars(int amount) {
        stars += amount;
        starsText.text = stars.ToString();
    }

    public void UseStars(int amount) {
        if (amount <= stars) {
            stars -= amount;
            starsText.text = stars.ToString();
        }
    }
}
