using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyPT : MonoBehaviour
{
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private Transform[] puntosDeMovimiento;
    [SerializeField] private float distanciaMin;

    private int SiguientePaso = 0;
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        Girar();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosDeMovimiento[SiguientePaso].position, velocidadDeMovimiento * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosDeMovimiento[SiguientePaso].position) < distanciaMin)
        {
            SiguientePaso += 1;
            if(SiguientePaso >= puntosDeMovimiento.Length)
            {
                SiguientePaso = 0; ;
            }

            Girar();
        }
    }

    private void Girar()
    {
        if(transform.position.x < puntosDeMovimiento[SiguientePaso].position.x)
        {
            theSR.flipX = true;
        }
        else
        {
            theSR.flipX = false;
        }
    }
}
