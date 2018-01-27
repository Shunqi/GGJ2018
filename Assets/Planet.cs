using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    private GameMgr gameMgr;

    public Sprite[] sprites;

    // Use this for initialization
    void Start () {
        gameMgr = GameObject.FindObjectOfType<GameMgr>();
    }

    public void Initialize(Vector3 pos)
    {
        transform.localScale = new Vector3(0.2f, 0.2f,0);
        transform.position = pos;
    }

    public void RandomizeSprite()
    {
        int index = (int)(Random.Range(0, 11));
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        FindObjectOfType<Bullet>().GetComponent<Bullet>().fired = true;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Add score
        //CameraShift
        FindObjectOfType<Envelope>().GetComponent<Envelope>().Show();
        collider.GetComponent<Bullet>().fired = false;
        collider.GetComponent<Bullet>().motherPlanet = transform;
        collider.GetComponent<Bullet>().NewPlanet();
        gameMgr.GetComponent<GameMgr>().AddScore(1);
    }

    // Update is called once per frame
    void Update () {
        CheckKeys();
	}

}
