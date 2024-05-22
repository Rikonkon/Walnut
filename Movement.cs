using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float winPositionX = 20f; // X-coordinate where the player wins

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        // Check for win condition
        if (transform.position.x >= winPositionX)
        {
            SceneManager.LoadScene("WinScene"); // Load a scene for winning
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("LoseScene"); // Load a scene for losing
        }
    }
}