using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Wall wall = hitInfo.GetComponent<Wall>();

        if (wall != null)
        {
            wall.TakeDamage(damage);
        }
    }
}
