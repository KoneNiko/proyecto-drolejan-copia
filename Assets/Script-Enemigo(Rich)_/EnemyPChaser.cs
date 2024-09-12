using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPChaser : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad del enemigo
    public float detectionRange = 5f; // Rango de detección del jugador
    public Transform pointA; // Punto A para patrullar
    public Transform pointB; // Punto B para patrullar

    private Vector3 currentTarget; // Objetivo actual al cual se dirige
    private bool chasingPlayer = false; // Estado de persecución

    void Start()
    {
        // Inicialmente se dirige al punto A
        currentTarget = pointA.position;
    }

    void Update()
    {
        // Calcular la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Cambiar entre estado de patrullaje y persecución
        if (distanceToPlayer < detectionRange)
        {
            // Si el jugador está dentro del rango, cambia al modo de persecución
            chasingPlayer = true;
        }
        else
        {
            // Si el jugador no está dentro del rango, patrulla
            chasingPlayer = false;
        }

        if (chasingPlayer)
        {
            // Perseguir al jugador
            ChasePlayer();
        }
        else
        {
            // Patrullar entre los puntos A y B
            Patrol();
        }
    }

    void Patrol()
    {
        // Mover al enemigo hacia el objetivo actual
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Verificar si llegó al objetivo
        if (Vector2.Distance(transform.position, currentTarget) < 0.1f)
        {
            // Cambiar el objetivo de patrullaje al otro punto
            currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        }
    }

    void ChasePlayer()
    {
        // Mover al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
