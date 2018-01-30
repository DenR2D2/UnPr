using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

	public float speed = 10f;
	//public float jumpRate = 2f;
    public float jump = 250f;
    public Transform groundCheck;
    public LayerMask whatIsGround;


	Vector3 movement;
	Rigidbody rb;
	float timer;
    bool isGrounded = false;
    float groundRadius = 0.5f;
    


	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
        
	}

	void Update()
	{
        if (isGrounded && Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector3(0f,jump,0f));
        }
        
    }

	void FixedUpdate ()
	{
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundRadius, whatIsGround);
        
		float h = Input.GetAxis ("Horizontal"); 
		Moving (h);
	}


	void Moving (float h)
	{
		movement.Set (h, 0f, 0f);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
	}
}
