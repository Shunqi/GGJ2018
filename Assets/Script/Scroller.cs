using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Camera.main.transform.position.y > transform.position.y + 16)
        {
            transform.Translate(new Vector3(0, 16, 0));
        }
	}
}
