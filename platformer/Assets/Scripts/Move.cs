using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

	public float speed = 10f;

	Vector3 movement;
	Rigidbody rb;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		Moving (h);
	}

	void Moving (float h)
	{
		movement.Set (h, 0f, 0f);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
	}
}
