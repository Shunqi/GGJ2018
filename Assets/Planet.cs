using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

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
		int index = (int)(Random.Range(1, sprites.Length));
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameMgr.GetStatus() == 1 && FindObjectOfType<Bullet>().GetComponent<Bullet>().fired == false)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (!FindObjectOfType<Bullet>().GetComponent<Bullet>().clockWiseRotation)
		{
			FindObjectOfType<Bullet>().GetComponent<Bullet>().clockWiseRotation = true;
		}
		else FindObjectOfType<Bullet>().GetComponent<Bullet>().clockWiseRotation = false;
        if (FindObjectOfType<Bullet>().GetComponent<Bullet>().clockWiseRotation
            && FindObjectOfType<Bullet>().GetComponent<Bullet>().entranceAngle < (FindObjectOfType<Bullet>().GetComponent<Bullet>().angle + 2 * Mathf.PI))
        {
            FindObjectOfType<Bullet>().GetComponent<Bullet>().bonus = true;

        }
        else if (!FindObjectOfType<Bullet>().GetComponent<Bullet>().clockWiseRotation
            && FindObjectOfType<Bullet>().GetComponent<Bullet>().entranceAngle > (FindObjectOfType<Bullet>().GetComponent<Bullet>().angle - 2 * Mathf.PI))
        {
            FindObjectOfType<Bullet>().GetComponent<Bullet>().bonus = true;
        }
        else FindObjectOfType<Bullet>().GetComponent<Bullet>().bonus = false;
        FindObjectOfType<Bullet>().GetComponent<Bullet>().fired = true;
		FindObjectOfType<Bullet>().GetComponent<Bullet>().RotateSpeed += 0.05f;
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Add score
        //CameraShift
        FindObjectOfType<Envelope>().GetComponent<Envelope>().Show();
        collider.GetComponent<Bullet>().fired = false;
        collider.GetComponent<Bullet>().motherPlanet = transform;
        collider.GetComponent<Bullet>().NewPlanet();
        if (FindObjectOfType<Bullet>().bonus)
        {
            gameMgr.GetComponent<GameMgr>().AddScore(2);
        }
        else gameMgr.GetComponent<GameMgr>().AddScore(1);
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("updating in planet");
        CheckKeys();
	}

}