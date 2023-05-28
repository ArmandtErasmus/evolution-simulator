using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour // Random Movement script
{
    [SerializeField]
    private List<Vector2> path;
    
    private int step;

    private Vector2 startPosition;

    private Vector2 nextWaypoint;
    [SerializeField]
    private float speed, range;

    private bool isMoving;

    private void Awake()
    {   
        path = new List<Vector2>();
        startPosition = transform.position;
        StartMoving();
    }

    private void StartMoving()
    {
        transform.position = startPosition;
        step = -1;
        SetNextWaypoint();
        isMoving = true;

    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            MoveTowardsNextWaypoint();
        }
    }

    private void MoveTowardsNextWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextWaypoint,Time.fixedDeltaTime * speed);
        if ((Vector2)transform.position == nextWaypoint)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        step++;

        if (step < path.Count)
        {
            nextWaypoint = CreateWaypoint(transform.position, range); //nextWaypoint = path[step];
        }
        else
        {
            nextWaypoint = CreateWaypoint(transform.position, range);  
        }
    }

    private Vector2 CreateWaypoint(Vector2 origin, float range)
    {
        Vector2 newWaypoint = Random.insideUnitCircle * range + origin;
        path.Add(newWaypoint);
        return newWaypoint;
    }

    //private void Update()
    //{
        
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
           // StartMoving();
       // }
    //}
}
