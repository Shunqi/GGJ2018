using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour {

	int prevWidth;

	// Use this for initialization
	void Start () {
		//Screen.SetResolution(768, 1024, false);
		Screen.SetResolution(1536, 2048, false);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		/*
		if (prevWidth != Screen.width)
		{
			Screen.SetResolution(Screen.width, Screen.width / 3 * 4, false);
			prevWidth = Screen.width;
		}
		*/
	}
}
