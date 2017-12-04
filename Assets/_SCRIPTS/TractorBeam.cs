using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour {

    public LayerMask collectables;
    public GameObject tractorBeam;
    AudioSource beamAudio;



    private void Start() {
        tractorBeam.SetActive(false);
        beamAudio = tractorBeam.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButton(0)) {

            tractorBeam.SetActive(true);
            StartCoroutine(playAudio());
            
            FireBeam();
            }

        if (Input.GetMouseButtonUp(0)) {
            tractorBeam.SetActive(false);
            //beamAudio.Stop();
            StopCoroutine(playAudio());
        }
	}

    IEnumerator playAudio() {
        beamAudio.Play();
        yield return new WaitForSeconds(beamAudio.clip.length);
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
