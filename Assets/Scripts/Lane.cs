using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

    private Radar radar;

    // Use this for initialization
    void Start() {
        radar = GetComponentInChildren<Radar>();
    }

    public void EnemySpawned() {
        radar.PopField();
    }
}
