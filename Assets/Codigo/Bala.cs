using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 10f;

    Rigidbody2D rb;



    void Start()
    {
        firePoint = GameObject.Find("firePoint").GetComponent<Transform>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
