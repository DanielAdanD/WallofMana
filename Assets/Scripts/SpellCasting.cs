using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBallPrefab;
    public GameObject ManaMPrefab;
    public float ManaMDelay = 0.2f;
    public float currentManaMDelay = 0;
    public float FireBDelay = 1f;
    public float currentFireBDelay = 0;
    

    public float castForce = 40f;

    private void Update()
    {
        if (currentManaMDelay <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                CastManaM();
            }
        }

        else
        {
            currentManaMDelay -= Time.deltaTime;
        } 

        if(currentFireBDelay <= 0) { 
            if (Input.GetButton("Fire4"))
            {
                CastFire();
            }

        }
        else
        {
            currentFireBDelay -= Time.deltaTime;
        }
    }
    void CastFire()
    {
        GameObject FireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = FireBall.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * castForce, ForceMode2D.Impulse);
        currentFireBDelay = FireBDelay;
    }
    void CastManaM()
    {
        GameObject ManaMissile = Instantiate(ManaMPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = ManaMissile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * castForce, ForceMode2D.Impulse);
        currentManaMDelay = ManaMDelay;
    }
}
