using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    public Transform rocket;
    private bool show = false;
    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        rocket = FindObjectOfType<Bullet>().transform;
        transform.localScale = new Vector3(0.1f, 0.1f, 0);
        transform.position = rocket.position;
    }
    private void Hide()
    {
        show = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
    public void Show()
    {
        
        show = true;
        GetComponent<SpriteRenderer>().enabled = true;
        transform.localScale = new Vector3(0.1f, 0.1f, 0);
        transform.position = rocket.position;

        Invoke("Hide", 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            transform.localScale /= 1.03f;
            transform.position = Vector3.MoveTowards(transform.position, rocket.GetComponent<Bullet>().motherPlanet.position,0.08f);
        }
    }
}
