
using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 500.0f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0.0f, jumpForce));
        }

        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("IsJumping", Mathf.Abs(rb.linearVelocity.y) > 0.01f);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }
}
