using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float health;
    float maxHealth = 100;
    [SerializeField]
    Image healthbar;


    
	void Start () {
        health = maxHealth;
	}
    private void OnEnable() {
        GameManager.OnDeath += KillPlayer;
        GameManager.RespawnPlayer += Respawn;
    }

    private void OnDisble() {
        GameManager.OnDeath -= KillPlayer;
        GameManager.RespawnPlayer -= Respawn;
    }

    public void TakeDamage(float damage, AudioSource effect) {
        
        health -= damage;
        effect.Play();
        healthbar.fillAmount = health / maxHealth;
        if (health <= 0) {
            AudioSource deathAudio = GetComponent<AudioSource>();
            deathAudio.Play();
            GameManager.Instance.CallOnDeath();
        }
    }

   void KillPlayer() {
        cam.transform.parent = null;
        this.gameObject.SetActive(false);
        // call respawn
    }

   void  Respawn() {
        this.gameObject.SetActive(true);
        cam.transform.parent = this.gameObject.transform;
    }
}
