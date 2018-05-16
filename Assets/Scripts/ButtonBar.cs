using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBar : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private static ButtonBar[] buttonBarArray;

    private void Start() {
        buttonBarArray = GameObject.FindObjectsOfType<ButtonBar>();
        PaintBlack();
    }

    private void OnMouseDown() {
        PaintBlack();
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }


    void PaintBlack() {
        foreach (ButtonBar thisButton in buttonBarArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    public static void UnselectDefender() {
        foreach (ButtonBar thisButton in buttonBarArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        selectedDefender = null;
    }
}
