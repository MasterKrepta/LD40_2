using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    Rigidbody2D rb;
    GameObject cargoHold;
    [SerializeField]
    private float speed = 1.5f;

 
    // Use this for initialization
    private void Awake() {
        cargoHold = FindObjectOfType<TractorBeam>().gameObject;
    }
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.gravityScale == 0) {
            transform.position = Vector3.MoveTowards(transform.position, cargoHold.transform.position, speed * Time.deltaTime);
        }
	}

    public void Tractor(GameObject hold) {
        
        MoveBackandForth moveScript = GetComponent<MoveBackandForth>();
        moveScript.enabled = false;
        rb.gravityScale = 0;
        
    }
    
}
