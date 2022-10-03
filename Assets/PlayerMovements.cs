using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

private float dirX = 0f;
 [SerializeField] private float moveSpeed = 7f;
 [SerializeField] private float jumpForce = 7f;

private enum MovementState { idle, running, jumping, falling }
private MovementState state = MovementState.idle;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   private void Update()
    {
        //Horizontal Movement (left/right) --> dirX=direction
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        //Jump Movement
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
       //Running Animator
       //sprite.flipX --> allows character to move in both directions
       private void UpdateAnimationState()
       {
        if (dirX > 0f)
        {
            anim.SetBool("run", true); 
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("run", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("run", false);
        }
       }

}