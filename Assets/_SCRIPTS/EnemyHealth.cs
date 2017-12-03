using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float health = 2;
    // Use this for initialization

    private void OnEnable() {
        GameManager.OnTreatIncrease += IncreaseHealth;
    }

    private void OnDisable() {
        GameManager.OnTreatIncrease -= IncreaseHealth;
    }

    public void TakeDamage(float damage, AudioSource effect) {
        Debug.Log(effect.clip.name);
       
        effect.Play();
        health -= damage;

        if(health <= 0) {
            AudioSource deathAudio = GetComponent<AudioSource>();
            deathAudio.Play();
            
            Destroy(gameObject);
        }
    }
	
    
	// Update is called once per frame
	void Update () {
		
	}

    void IncreaseHealth() {
        health += 2;
    }
}
