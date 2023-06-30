using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject castPrefab;

    public float castForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Cast();
        }
    }
    void Cast()
    {
        GameObject Casting = Instantiate(castPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Casting.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * castForce, ForceMode2D.Impulse);
    }
}
