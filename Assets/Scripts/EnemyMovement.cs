using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public float speed = 3f;
    int waypointIndex = 0; 
    private float hor;
    public bool facingRight = true;
    [SerializeField] private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            Move();
            Flip();
        }
    }

    void Move()
    {
        
        anim.SetFloat("Speed", 1f);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
            speed * Time.deltaTime);

        if (transform.position.x == waypoints[waypointIndex].transform.position.x)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0; 
        }
    }
    
    private void Flip()
    {
        if ((waypoints[waypointIndex].transform.position.x > transform.position.x) && facingRight || (waypoints[waypointIndex].transform.position.x < transform.position.x) && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
}
