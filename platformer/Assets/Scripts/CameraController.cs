using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float maxDifference;
    public float speed = 10f;

    Rigidbody rb;
    float difference;
    Vector3 movement;
    float playerPosition;




    void Start()
    {
        rb = GetComponent<Rigidbody>();         
        
    }


    void Update()
    {
        difference = transform.position.x - player.transform.position.x;
        if (difference > maxDifference)
        {
            playerPosition = player.transform.position.x;
            Moving(playerPosition);
        }
        if (difference < -maxDifference)
        {
            playerPosition = player.transform.position.x;
            Moving(playerPosition);
        }

    }

    void Moving(float h)
    {
        movement.Set(h, 0f, 0f);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
}
