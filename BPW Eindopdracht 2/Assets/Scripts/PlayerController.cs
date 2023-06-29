using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded = false;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Haalt de WASD input op
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);

        //als W ingedrukt en krakter staat op de grond, Spring omhoog
        if (vertical > 0 && isGrounded)
        {
            ContactPoint2D[] contacts = new ContactPoint2D[10];
            int numContacts = rigidBody2D.GetContacts(contacts);
            bool canJump = false;
            //checked voor elke contact point of het onder het karakter is.
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

    //Fuction word gebruikt voor Loopholes
    public void TeleportY(float y){
        transform.position += new Vector3(0,y,0);
    }
}
