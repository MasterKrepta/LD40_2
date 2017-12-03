using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour {

    public GameObject target;
    public Transform bullet;
    public float fireRate = 2f;
    public float detectRadius = 4f;
    bool canShoot = true;

    public LayerMask enemyLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DetectTarget();
        if(target != null && canShoot) {
            canShoot = false;
            Fire();
        }
	}

    void DetectTarget() {

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectRadius, enemyLayer);
        try {
            target = hitColliders[0].gameObject;
        }
        catch {
            //this.gameObject.SetActive(false);
            target = null;
            return;
        }

        float dist = Vector2.Distance(transform.position, hitColliders[0].transform.position);
        for (int i = 0; i < hitColliders.Length; i++) {

            float tempDist = Vector2.Distance(transform.position, hitColliders[i].transform.position);

            if (tempDist < dist) {
                target = hitColliders[i].gameObject;
            }
        }

    }

    void Fire() {
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay() {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
