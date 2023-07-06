using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject castPrefab;

    public float castForce = 40f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            CastFire();
        }
    }
    void CastFire()
    {
        GameObject FireBall = Instantiate(castPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = FireBall.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * castForce, ForceMode2D.Impulse);
    }
}
