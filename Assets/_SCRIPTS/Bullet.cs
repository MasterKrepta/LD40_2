using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float speed = 5.0f;

    [SerializeField]
    float damage = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += (transform.up) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {
            
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
