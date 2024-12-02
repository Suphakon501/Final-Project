using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Character
{
    public float moveSpeed;
    public GameObject[] wayPoint;

    int nextWaypoint = 1;
    float distToPoint;
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, wayPoint[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, wayPoint[nextWaypoint].transform.position, moveSpeed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Character>().TakeDamage(1);
        }

    }
    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoint[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWayPoint();
    }
    void ChooseNextWayPoint()
    {
        nextWaypoint++;
        if (nextWaypoint == wayPoint.Length)
        {
            nextWaypoint = 0;
        }
    }
}