﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;
    protected Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameObject obj = other.gameObject;

        if (obj.GetComponent<Defender>()) {
            animator.SetBool("isAttacking", false);
        }
    }


    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float dmg) {

        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(dmg);
            }
        }
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;

    }
}
