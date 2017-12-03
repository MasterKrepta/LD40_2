using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform player;
    public float distance = 10f;
    public GameObject bulletPrefab;
    public float shootDelay = .5f;


    private void OnDisable() {
        CancelInvoke();
    }
    private void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ShootForward", shootDelay, shootDelay);
    }


    void ShootForward() {
        if((Vector3.Distance(player.position, transform.position)) <= distance){

        
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        }



    }
}