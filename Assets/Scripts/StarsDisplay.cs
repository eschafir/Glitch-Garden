using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class StarsDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE };

    private int stars = 100;
    private Text starsText;

    // Use this for initialization
    void Start() {
        starsText = GetComponent<Text>();
        starsText.text = stars.ToString();
    }


    public void AddStars(int amount) {
        stars += amount;
        starsText.text = stars.ToString();
    }

    public Status UseStars(int amount) {
        if (amount <= stars) {
            stars -= amount;
            starsText.text = stars.ToString();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
