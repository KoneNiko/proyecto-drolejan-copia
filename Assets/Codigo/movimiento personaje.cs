using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class movimientopersonaje : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject bullet;
    public Transform firePoint;
    public bool weapon;
    private Rigidbody2D rb;
    private bool isGrounded;
    public GameObject Bala;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        if (Input.GetKeyDown(KeyCode.F)&&weapon==true)
        {
            Bala = Instantiate(bullet,firePoint.transform.position,Quaternion.identity);
            Bala.GetComponent<Bala>().bulletSpeed *= -1;
        }
        print(Bala.GetComponent<Bala>().bulletSpeed);
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            firePoint.transform.localScale = new Vector3(1, 1, 1);
            Bala.GetComponent<Bala>().bulletSpeed = 10;
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            firePoint.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded= false;
        }
    }
}


