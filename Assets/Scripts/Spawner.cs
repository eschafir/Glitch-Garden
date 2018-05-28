using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabsArray;
    public float delay;

    private Lane thisLane;

    private void Start() {
        SetLane();
    }

    // Update is called once per frame
    void Update() {
        foreach (GameObject attacker in attackerPrefabsArray) {
            if (isTimeToSpawn(attacker)) {
                Spawn(attacker);
            }
        }
    }

    void SetLane() {
        Lane[] allLanes = GameObject.FindObjectsOfType<Lane>();
        foreach (Lane lane in allLanes) {
            if (lane.transform.position.y == transform.position.y) {
                thisLane = lane;
                return;
            }
        }
        Debug.LogError(name + ": No Lane found");
    }

    bool isTimeToSpawn(GameObject enemy) {
        Attacker attacker = enemy.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1f / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("Spawn rate capped by frame rrate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / delay;

        return (Random.value < threshold);
    }

    void Spawn(GameObject myGameObject) {
        Instantiate(myGameObject, transform.position, Quaternion.identity, transform);
        thisLane.EnemySpawned();
    }
}