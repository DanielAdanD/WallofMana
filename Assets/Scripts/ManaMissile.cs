using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaMissile : MonoBehaviour
{
    public GameObject hitEffect;
    public Rigidbody2D rb;
    public int damage = 25;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}

