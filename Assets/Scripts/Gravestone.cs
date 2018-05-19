using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.GetComponent<Attacker>()) {
            animator.SetTrigger("underAttack trigger");
        }
    }
}
