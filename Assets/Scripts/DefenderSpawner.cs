using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;
    private StarsDisplay starsDisplay;

    private void Start() {
        starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown() {
        Vector2 position = SnapToGrid(CalculateWorldPointOfMouseClick());

        if (ButtonBar.selectedDefender) {
            int defenderCost = ButtonBar.selectedDefender.GetComponent<Defender>().starCost;
            if (starsDisplay.UseStars(defenderCost) == StarsDisplay.Status.SUCCESS) {
                SpawnDefender(position);
            } else {
                Debug.Log("Insufficient stars");
            }
        }
    }

    private void SpawnDefender(Vector2 position) {
        Instantiate(ButtonBar.selectedDefender, position, Quaternion.identity, defenderParent.transform);
        ButtonBar.UnselectDefender();
    }

    private Vector2 CalculateWorldPointOfMouseClick() {
        Camera camera = GameObject.FindObjectOfType<Camera>();
        float x = camera.ScreenToWorldPoint(Input.mousePosition).x;
        float y = camera.ScreenToWorldPoint(Input.mousePosition).y;
        return new Vector2(x, y);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
