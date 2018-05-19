using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;
    public AudioClip launchClip;

    private void Start() {
        AudioSource.PlayClipAtPoint(launchClip, transform.position);
    }

    void Update() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Add hit sound
        GameObject obj = other.gameObject;

        if (obj.GetComponent<Attacker>()) {
            Health health = obj.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
