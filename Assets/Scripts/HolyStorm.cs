using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyStorm : MonoBehaviour
{
    public int damage = 10;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject, 2f);
    }
}

