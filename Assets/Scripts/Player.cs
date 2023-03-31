using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    private Collider2D playerCollider;

    public float distToGround;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    //animations
    public Animator playerAnimator;
    public SpriteRenderer playerRenderer;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        } 
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        isGrounded = GroundCheck();


        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);

        }
        if (Input.GetButtonDown("Jump") && player.velocity.y > 0f)
        {
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, 0.5f);

            coyoteTimeCounter = 0f;
        }

        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
        
          //Sprite Flipping
        if (player.velocity.x > 0 && playerRenderer.flipX == true)
        {
            playerRenderer.flipX = false;
        }
        if (player.velocity.x < 0 && playerRenderer.flipX == false)
        {
            playerRenderer.flipX = true;
        }
        if (!isGrounded)
        {
            playerAnimator.SetBool("isMoving", false);
            return;
        }

        //Animator
        if (player.velocity.x != 0 )
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }

    }

    public bool isGrounded = false;

    public bool GroundCheck()
    {
        Bounds bounds = this.playerCollider.bounds;
        Vector3 rayOrigin = bounds.center;
        rayOrigin.y -= bounds.extents.y;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, 0.1f);
        if (hit.collider != null)
        {
            Debug.Log("Collider is: " + hit.collider.name);
        }

        return hit.collider != null;
    }

}
