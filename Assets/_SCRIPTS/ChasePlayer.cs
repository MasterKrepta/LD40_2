using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public GameObject target;
    Rigidbody2D rb;
    public float missleSpeed = 10f;
    float rotSpeed = 300f;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveToTarget();
	}

    void MoveToTarget() {
        if (target != null) {

            Vector2 dir = (Vector2)target.transform.position - rb.position;
            dir.Normalize();

            float rotAmount = Vector3.Cross(dir, transform.up).z;

            rb.angularVelocity = -rotAmount * rotSpeed;

            rb.velocity = -transform.right * missleSpeed;
            
        }

    }
}
