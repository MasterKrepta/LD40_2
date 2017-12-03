using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour {

    public LayerMask collectables;
    
    



    private void OnEnable() {
        
        
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0)) {

           
                FireBeam();
            }
	}

    void FireBeam() {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue, 1.5f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - transform.position, collectables);
        
        if (hit.collider != null) {
            if (hit.collider.tag == "Collectable") {
                //Debug.Log("hit " + hit.collider);
                
                hit.collider.GetComponent<Collectable>().Tractor(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Collectable") {
            AudioSource effect = GetComponent<AudioSource>();
            effect.Play();
            GameManager.Instance.CallOnPickup();
            Destroy(collision.gameObject);

        }
    }
}
