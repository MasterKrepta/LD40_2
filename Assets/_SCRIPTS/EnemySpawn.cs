using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    private int enemiesToSpawn = 2;

    [SerializeField]
    private int spawnRadius = 20;
    Transform player;

    public Transform enemy;
    
    // Use this for initialization
    private void OnEnable() {
        GameManager.OnTreatIncrease += IncreaseEnemies;
    }

    private void OnDisable() {
        GameManager.OnTreatIncrease -= IncreaseEnemies;
    }
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            //int randomSpawn = Random.Range(0, spawnpoints.Length);
            //Transform go =  Instantiate(enemy, spawnpoints[randomSpawn].position, transform.rotation) as Transform;
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            
            if(randomPos.y < -3) {
                randomPos.y *= -1;
            }

            Transform go = Instantiate(enemy, randomPos, transform.rotation) as Transform;
            //go.parent = this.gameObject.transform;
            
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }


}
