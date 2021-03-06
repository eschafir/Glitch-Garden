﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;


    public void DealDamage(float damage) {

        if (GetComponent<Attacker>()) {
            Attacker attacker = GetComponent<Attacker>();
            attacker.Bleed();
        }


        health -= damage;
        if (health <= 0f) {
            //Optionally trigger dead animation
            DestroyObject();
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }

}
