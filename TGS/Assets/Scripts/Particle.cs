using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

    ParticleSystem particle;

    // Use this for initialization
    void Start () {
        particle = GetComponent<ParticleSystem>();
        //Debug.Log(transform.tag);
        if (transform.tag == "FireWorks") {
            particle.startColor = new Color(1, transform.position.y/8f,0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!particle.isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
