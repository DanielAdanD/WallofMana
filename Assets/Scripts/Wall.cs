using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Vector2 movement;
    private Animator animator;
    private Rigidbody2D rb;
    public int health = 100;
    public GameObject deathEffect;
    public GameObject gameOverMenu;

    public void TakeDamage (int damageAmount)
    { 
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
            gameOver();
        }
    }

    private void Die()
    {
        Debug.Log("The wall was destroyed!");
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
    private void gameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
