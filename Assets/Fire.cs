using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public Transform rocket;
	// Use this for initialization
	void Start () {
        rocket = FindObjectOfType<Bullet>().transform;
        transform.localScale = new Vector3(0.15f, 0.15f, 0);
        transform.position = rocket.position + 0.8f*transform.right;
        transform.rotation = rocket.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<Bullet>().fired)
        {
            
            transform.position = rocket.position + 0.8f * transform.right;
            transform.rotation = rocket.rotation;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            transform.position = rocket.position + 0.8f * transform.right;
            transform.rotation = rocket.rotation;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}
