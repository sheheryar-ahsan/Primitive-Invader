using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Transform playerPos;
    public int speed;
    public float playerBound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerPos = GetComponent<Transform>();
    }
    void Update()
    {
        PlayerMovement();
        PlayerBounds();
    }
    private void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            playerRb.velocity = new Vector2(xInput * speed, playerRb.velocity.y);
            playerRb.gravityScale = 0;
        }
    }
    private void PlayerBounds()
    {
        if (playerPos.transform.position.x < -playerBound)
        {
            transform.position = new Vector3(-playerBound, transform.position.y);
        }
        else if (playerPos.transform.position.x > playerBound)
        {
            transform.position = new Vector3(playerBound, transform.position.y);
        }
    }
    
}
