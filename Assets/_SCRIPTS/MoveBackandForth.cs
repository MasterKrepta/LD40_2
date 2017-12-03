using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour {

    public float speed = 10f;
 
    public float randTime = 0;
    [SerializeField]
    private float minTime = 2f;
    [SerializeField]
    private float maxTime = 5f;
    bool moveLeft = true;

    // Use this for initialization
    void Start () {
        GetRandomTime();
	}

    private void Update() {
        randTime -= Time.deltaTime;

        if (moveLeft) {
            MoveLeft();
        }
        else {
            MoveRight();
        }
    }

    void MoveRight () {
        
        transform.position += transform.right * speed * Time.deltaTime;
        if(randTime <= 0) {
            Flip();
            GetRandomTime();
            MoveLeft();
        }
    }

    void MoveLeft() {
        
        transform.position += -transform.right * speed * Time.deltaTime;
        if (randTime <= 0) {
            Flip();
            GetRandomTime();
            MoveRight();
        }
    }


    void Flip() {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        moveLeft = !moveLeft;
    }

    void GetRandomTime() {
        
        randTime = Random.Range(minTime, maxTime);
        //Debug.Log(randTime + " remaining");
    }
}
