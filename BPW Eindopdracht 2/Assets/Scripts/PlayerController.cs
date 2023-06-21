using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
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

        if (vertical > 0 && isGrounded)
        {
            // check if the player is colliding with the ground from the top
            ContactPoint2D[] contacts = new ContactPoint2D[10]; // allocate more than one contact point
            int numContacts = rigidBody2D.GetContacts(contacts);
            bool canJump = false;
            for (int i = 0; i < numContacts; i++)
            {
                if (contacts[i].normal == Vector2.up)
                {
                    canJump = true;
                    break;
                }
            }
            if (canJump)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
