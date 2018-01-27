using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    private GameMgr gameMgr;

	// Use this for initialization
	void Start () {

        GameObject GameManagerObject = GameObject.Find("GameManager");

        gameMgr = GameManagerObject.GetComponent<GameMgr>();
    }

    public void Initialize(Vector3 pos)
    {
        transform.position = pos;
        transform.localScale = new Vector3(0.2f, 0.2f,0);
    }

    private void CheckKeys()
    {
        if(Input.GetKeyDown(KeyCode.Space)) { Fire(); }
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
        gameMgr.AddScore(1);
    }

    // Update is called once per frame
    void Update () {
        CheckKeys();
	}

}
