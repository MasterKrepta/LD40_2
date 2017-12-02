using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    
    private int enemiesToSpawn = 2;

    public Transform enemy;
    public Transform[] spawnpoints;
    // Use this for initialization
    private void OnEnable() {
        GameManager.OnTreatIncrease += IncreaseEnemies;
    }

    private void OnDisable() {
        GameManager.OnTreatIncrease -= IncreaseEnemies;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void IncreaseEnemies() {
        enemiesToSpawn *= 2;
        SpawnWave();
    }

    void SpawnWave() {
        for (int i = 0; i < enemiesToSpawn; i++) {
            int randomSpawn = Random.Range(0, spawnpoints.Length);
            Instantiate(enemy, spawnpoints[randomSpawn].position, transform.rotation);
        }
    }
}
