using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start() {
        animator = GetComponent<Animator>();


        // Create parent object if necessary
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }


        SetMyLaneSpawner();
    }

    private void Update() {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    // Look through all spawners, and set myLaneSpawner if found
    void SetMyLaneSpawner() {
        Spawner[] allSpawners = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in allSpawners) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + ": No Spawner found");
    }

    bool IsAttackerAheadInLane() {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }
        return false;
    }

    private void Fire() {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;

    }
}
