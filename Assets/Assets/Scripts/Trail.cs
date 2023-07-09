using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        trail = gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "thorn" || other.gameObject.tag == "deathbed")
        {
            trail.Clear();
        }
    }
}
