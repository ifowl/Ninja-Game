using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rbody;
    private Animator anim;
    private bool grounded;
    public bool dead;


    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rbody.velocity = new Vector2(horizontalInput * speed, rbody.velocity.y);

            if (horizontalInput > 0.01f) //if player moving right
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
            else if (horizontalInput < -0.01f) //player is moving left
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);

            anim.SetBool("isRunning", horizontalInput != 0);
            anim.SetBool("isGrounded", grounded);

            if (Input.GetKey(KeyCode.UpArrow) && grounded)
                Jump();
        } else
        {
            rbody.velocity = Vector2.zero;
        }

        if (transform.position.y < -30)
        {
            GetComponent<Health>().TakeDamage(100);
        }
    }
    private void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
