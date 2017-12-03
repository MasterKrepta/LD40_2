using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public  Transform target;
    public float trackingSpeed = 30f;

    // Use this for initialization
    void Start() {
        try {
            target = GameObject.FindWithTag("Player").transform;
        }
        catch {
            Debug.Log("player cant be set so disable");

        }
    }

    // Update is called once per frame
    void Update() {


        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    }
}