using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundElements : MonoBehaviour {

	public Sprite[] sprites;
	public float angularSpeed;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {

		originalPosition = transform.position;
		int index = (int)(Random.Range(0, sprites.Length));
		GetComponent<SpriteRenderer>().sprite = sprites[index];
		angularSpeed = Random.Range(-40, 40);
		
	}
	
	// Update is called once per frame
	void Update () {
		// Retrieve screen points
		var bottomleft = Camera.main.ViewportToWorldPoint(Vector3.zero);
		var topright = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

		// Rotating object
		Vector3 euler = transform.eulerAngles;
		euler.z += angularSpeed * Time.deltaTime;
		transform.eulerAngles = euler;

		// Move object to the top of the screen
		if (transform.position.y < bottomleft.y - 2f)
		{
			Vector3 position = transform.position;
			position.x = Random.Range(bottomleft.x + 2f, topright.x - 2f);
			position.y = topright.y + 2f;
			transform.position = position;
			int index = (int)(Random.Range(0, sprites.Length));
			GetComponent<SpriteRenderer>().sprite = sprites[index];
			angularSpeed = Random.Range(-40, 40);
		}
	}

	// Revert the original position
	public void ResetPosition()
	{
		transform.position = originalPosition;
	}
}
