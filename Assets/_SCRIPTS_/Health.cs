using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

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
    }

    private void OnDisble() {
        GameManager.OnDeath -= KillPlayer;
    }

    public void TakeDamage(float amount) {
        health -= amount;
        healthbar.fillAmount = health / maxHealth;
        if (health <= 0) {
            GameManager.Instance.CallOnDeath();
        }
    }

   void KillPlayer() {
        this.gameObject.SetActive(false);
    }
}
