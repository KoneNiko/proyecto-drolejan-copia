using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;

    public float moveSpeed;
    public float timeAtPoints;
    private float waitCounter;
    void Start()
    {
        foreach(Transform t in patrolPoints)
        {
            t.SetParent(null);
        }

        waitCounter = timeAtPoints;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < .01f )
        {   
            waitCounter -= Time.deltaTime;

            if(waitCounter <= 0 )
            {
                currentPoint++;
                if (currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }

                waitCounter = timeAtPoints;
            }
        }
    }
}
