using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabsArray;

    // Update is called once per frame
    void Update() {
        foreach (GameObject thisAttacker in attackerPrefabsArray) {
            if (isTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
    }

    bool isTimeToSpawn(GameObject myGameObject) {
        Attacker attacker = myGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("Spawn rate capped by frame rrate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 7;

        return (Random.value < threshold);
    }

    void Spawn(GameObject myGameObject) {
        Instantiate(myGameObject, transform.position, Quaternion.identity, transform);
    }
}
