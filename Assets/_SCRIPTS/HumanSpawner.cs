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

    private void OnEnable() {
        GameManager.OnPickup += CheckForHumanSpawn;
        
    }

    private void OnDisable() {
        GameManager.OnPickup -= CheckForHumanSpawn;
    }

    private void CheckForHumanSpawn() {
        currentHumans--;
        if (currentHumans <= 5) {
            SpawnHumans();
        }
    }
    void SpawnHumans() {
        
        for (int i = currentHumans; i < maxNumber; i++) {
            Vector3 randPos = GetRandomSpawnPoint();
            randPos.y = -5;
            Transform go =  Instantiate(human, randPos, Quaternion.identity) as Transform;
            go.parent = this.gameObject.transform;
            currentHumans++;
        }
        
    }

    Vector3 GetRandomSpawnPoint() {
        Vector3 randPos = new Vector3(Random.Range(minDistance, maxDistance), 0, 0);
        return randPos;
    }
}

