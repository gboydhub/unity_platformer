using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float runSpeed = 7.0f;
    [SerializeField] private float jumpVel = 18.0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask trapLayer;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    private enum MoveState { idle, running, jumping, falling }

    private MoveState movs = MoveState.idle;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.y,jumpVel);
        }
        UpdateSpriteAnimation();
    }

    private void UpdateSpriteAnimation()
    {
        if(dirX > 0f )
        {
            movs = MoveState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            movs = MoveState.running;
            sprite.flipX = true;
        }
        else
        {
            movs = MoveState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            movs = MoveState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            movs = MoveState.falling;
        }
        anim.SetInteger("state", (int)movs);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
