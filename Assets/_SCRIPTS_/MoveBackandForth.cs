using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour {

    public float speed = 10f;
 
    
    float time = 0;
    public float randTime = 0;
    [SerializeField]
    private float minTime = 5f;
    [SerializeField]
    private float maxTime = 15f;


    // Use this for initialization
    void Start () {
        GetRandomTime();
        MoveRight();
	}
	
	
	void MoveRight () {
        
    //    while(randTime > 0) {
            
            randTime -= Time.deltaTime;
            transform.position += transform.right * speed * Time.deltaTime;
      //  }
        
           Flip();
            GetRandomTime();
           // MoveLeft();
    }

    void MoveLeft() {
        
        while (randTime > 0) {
            randTime -= Time.deltaTime;
            transform.position += -transform.right * speed * Time.deltaTime;
        }
            Flip();
            GetRandomTime();
            MoveRight();
    }


    void Flip() {
        Vector3 theScale = transform.localScale;
        Vector3 thePosition = transform.position;
        theScale.x *= -1;
        transform.localScale = theScale;
        thePosition.x *= -1;
        transform.position = thePosition;
    }

    void GetRandomTime() {
        time = 0;
        randTime = Random.Range(minTime, maxTime);
        Debug.Log(randTime + " remaining");
    }
}
