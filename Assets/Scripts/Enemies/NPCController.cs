using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 2f; // speed of NPC's walking

    private Animator animator;

    private Rigidbody2D rb; // reference to the NPC's rigidbody

    private Vector2 movement; // direction for NPC to walk

    public float rayDistance = 1f; // distance of the raycast

    public LayerMask obstacleLayer; // layer mask of obstacles

    public Transform wall; // reference to the player's transform

    public float followRadius = 5f; // radius within which the NPC will start following the player

    public float followSpeed = 4f; // speed at which the NPC will follow the player

    public int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Wall wall = collision.gameObject.GetComponent<Wall>();
            wall.TakeDamage(damageAmount);
            animator.SetBool("isAttacking", true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, wall.position);

        if (distanceToPlayer <= followRadius)
        {
            // set the movement direction to move towards the player
            movement = (wall.position - transform.position).normalized;

            // move the NPC towards the player
            rb.velocity = movement * followSpeed;

            // flip the sprite if moving left
            if (movement.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (movement.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            // set the walk animation
            animator.SetBool("isFlying", true);
        }
        else
        {
            // move the NPC in the current direction
            rb.velocity = movement * moveSpeed;

            // check for obstacles
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, rayDistance, obstacleLayer);

            // set the walk animation if moving
            animator.SetBool("isFlying", movement.magnitude > 0);
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
