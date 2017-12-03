using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour {

    public Transform human;
    int maxNumber = 15;
    int currentHumans = 0;

    float minDistance = -50;
    float maxDistance = 50;
    // Use this for initialization
    void Start () {
        SpawnHumans();
	}


    private void Update() {
        if (currentHumans <= 13) {
            SpawnHumans();
        }
    }
    void SpawnHumans() {
        Debug.Log("Spawmomg");
        for (int i = currentHumans; i < maxNumber; i++) {
            Vector3 randPos = GetRandomSpawnPoint();
            randPos.y = -5;
            Instantiate(human, randPos, Quaternion.identity);
            currentHumans++;
        }
        
    }

    Vector3 GetRandomSpawnPoint() {
        Vector3 randPos = new Vector3(Random.Range(minDistance, maxDistance), 0, 0);
        return randPos;
    }
}

