using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float shootDelay = .5f;


    private void OnDisable() {
        CancelInvoke();
    }
    private void OnEnable() {
        InvokeRepeating("ShootForward", shootDelay, shootDelay);
    }


    void ShootForward() {
        
        Instantiate(bulletPrefab, transform.position, transform.rotation);

    

    }
}