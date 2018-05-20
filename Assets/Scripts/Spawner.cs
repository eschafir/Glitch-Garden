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
        foreach (GameObject thisAttacker in attackerPrefabsArray) {
            if (isTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
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

    bool isTimeToSpawn(GameObject myGameObject) {
        Attacker attacker = myGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

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