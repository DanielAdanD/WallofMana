using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public Transform firePoint;
    public Transform holyPoint;
    public GameObject fireBallPrefab;
    public GameObject ManaMPrefab;
    public GameObject HolyStormPrefab;
    public GameObject ThunderStrikePrefab;
    public float ThundersTrikeDelay = 5f;
    public float currentThundersTrikeDelay = 0f;
    public float ManaMDelay = 0.2f;
    public float currentManaMDelay = 0;
    public float FireBDelay = 1f;
    public float currentFireBDelay = 0;
    public float HolyStormDelay = 10f;
    public float currentHolyStormDelay = 0;
    

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
            if (Input.GetButton("Fire2"))
            {
                CastFire();
            }

        }
        else
        {
            currentFireBDelay -= Time.deltaTime;
        }
        if(currentThundersTrikeDelay <= 0)
        {
            if (Input.GetButton("Fire3"))
            {
                CastThunderStrike();
            }
        }
        else
        {
            currentThundersTrikeDelay -= Time.deltaTime;
        }
        if (currentHolyStormDelay <=0)
        {
            if (Input.GetButton("Fire4"))
            {
                CastHolyStorm();
            }
        }
        else
        {
            currentHolyStormDelay -= Time.deltaTime;
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
    void CastThunderStrike()
    {
        GameObject ThunderStrike = Instantiate(ThunderStrikePrefab, holyPoint.position, holyPoint.rotation);
        currentThundersTrikeDelay = ThundersTrikeDelay;
    }
    void CastHolyStorm()
    {
        GameObject HolyStorm = Instantiate(HolyStormPrefab, holyPoint.position, holyPoint.rotation );
        currentHolyStormDelay = HolyStormDelay;
    }
}
