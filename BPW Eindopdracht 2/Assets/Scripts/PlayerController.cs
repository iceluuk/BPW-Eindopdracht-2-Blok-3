using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 500f;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody2D.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
