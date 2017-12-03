using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnOffscreen : MonoBehaviour {

    // Use this for initialization
    
    private void OnEnable() {
        
        
    }

    private void Update() {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
