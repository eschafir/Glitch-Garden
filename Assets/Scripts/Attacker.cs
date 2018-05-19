using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Tooltip("Average number of second between appearances")]
    public float seenEverySeconds;
    public GameObject blood;

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

    public void Bleed() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z -1f );
        GameObject attackerBlood = Instantiate(blood, pos, Quaternion.identity, transform) as GameObject;
    }
}
