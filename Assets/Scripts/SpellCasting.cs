using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBallPrefab;
    public GameObject ManaMPrefab;

    public float castForce = 40f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            CastFire();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            CastManaM();
        }
    }
    void CastFire()
    {
        GameObject FireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = FireBall.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * castForce, ForceMode2D.Impulse);
    }
    void CastManaM()
    {
        GameObject ManaMissile = Instantiate(ManaMPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = ManaMissile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * castForce, ForceMode2D.Impulse);
    }
}
