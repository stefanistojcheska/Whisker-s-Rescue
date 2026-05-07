using System;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private BoxCollider2D boxColider;
    private void Awake()
    {
        //grab references
        body = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        boxColider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocityY);

        //cat go right
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2,2,2);
        } //cat go left
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded() && !onWall())
        {
            jump();
        }
        //set animator parametars
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", isGrounded());

    }
    private void jump()
    {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
