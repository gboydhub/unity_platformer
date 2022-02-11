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

    //rivate void UpdateSpriteAnimation();

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);
        UpdateSpriteAnimation();
    }

    private void UpdateSpriteAnimation()
    {
        if(Input.GetKeyDown("space")) 
        {
            rb.velocity = new Vector2(rb.velocity.y,jumpVel);
        }
        if(dirX > 0f )
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
