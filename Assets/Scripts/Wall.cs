using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Vector2 movement;
    private Animator animator;
    private Rigidbody2D rb;
    public int health = 100;
    public void TakeDamage (int damageAmount)
    { 
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("The wall was destroyed!");
        animator.SetBool("isDead", true);
    }
}
