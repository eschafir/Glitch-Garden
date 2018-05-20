using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume() + 0.1f;
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
