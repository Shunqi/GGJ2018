using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float RotateSpeed = 2f;
    private float ForwardSpeed = 5f;
    private float Radius;
    public float angle;
    //private float dist;
    private Vector2 center;
    public bool fired;
    public bool clockWiseRotation;
    private static Vector4 bounds;
    public Transform motherPlanet;

    // Use this for initialization
    void Start () {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        bounds.x = bottomleft.x;
        bounds.y = bottomleft.y;
        bounds.z = topright.x;
        bounds.w = topright.y;
        motherPlanet = FindObjectsOfType<Planet>()[0].transform;
        center = motherPlanet.transform.position;
        Radius = 8f * motherPlanet.localScale.x;
        fired = false;
        angle = 0;
    }
	private void Circular()
    {
        angle += RotateSpeed * Time.deltaTime;
        //Debug.Log(angle / 2 / Mathf.PI - 0.25);
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        //dist += (center - offset - (Vector2)transform.position).magnitude;
        transform.position = center - offset;


        //var originRotation = transform.rotation.z;
        var dir = (transform.position - (Vector3)center).normalized;
        var norm = dir;
        norm.x = -dir.y;
        norm.y = dir.x;
        transform.right = norm;
        //transform.rotation = Quaternion.Euler(0, 0, originRotation - dist* 360/(2*Mathf.PI*Radius));
    }
    private void Forward()
    {
        transform.position += (-transform.right) * Time.deltaTime * ForwardSpeed;
    }

    public void NewPlanet()
    {
        if (((Vector3)center - transform.position).y < 0)
        {
            angle = Mathf.Asin(((Vector3)center - transform.position).x / Radius);
        }
        else angle = Mathf.PI - Mathf.Asin(((Vector3)center - transform.position).x / Radius);
        center = motherPlanet.transform.position;
		GameObject.Find("BGM Controller").GetComponent<BGMController>().SuccessBeepPlay();
    }
	// Update is called once per frame
	void Update () {
        if (!fired)
        {
            Circular();
        }
        if (fired)
        {
            Forward();
        }
        var pos = transform.position;

        if (pos.x < bounds.x || pos.x > bounds.z || pos.y < bounds.y || pos.y > bounds.w)
        {
            //GameOver
            Debug.Log("GG");
        }
    }
}
