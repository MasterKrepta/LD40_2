using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 5f;
    public Transform art;
    public float tilt = .2f;
    
    Rigidbody2D rb;
	
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void Update() {
        //Move();
    }
    private void FixedUpdate() {
        
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(movement * speed * Time.deltaTime);

        art.rotation = Quaternion.Euler(0.0f, 0, movement.x * -tilt);
        
    }

    private void Move() {
       Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
       art.rotation = Quaternion.Euler(0.0f, 0, movement.x * -tilt);



    }
}
