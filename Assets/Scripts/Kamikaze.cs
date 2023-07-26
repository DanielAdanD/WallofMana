using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public int damage = 10;
    public GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Wall wall = hitInfo.GetComponent<Wall>();

        if (wall != null)
        {
            wall.TakeDamage(damage);
            Die();
        }
    }
    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }
}
