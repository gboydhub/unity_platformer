using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float runSpeed = 7.0f;
    [SerializeField] private float jumpVel = 18.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    private enum MoveState { idle, running, jumping, falling }

    private MoveState movs = MoveState.idle;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.y,jumpVel);
        }
        UpdateSpriteAnimation();
    }

    private void UpdateSpriteAnimation()
    {
        MoveState state;
        if(dirX > 0f )
        {
            state = MoveState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = MoveState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MoveState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MoveState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MoveState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
}
