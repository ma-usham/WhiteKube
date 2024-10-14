using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float waitDuration = 4f;
    private Vector3 targetPos;
    private Vector2 velocity;
    public Transform posA, posB;

    private bool waiting = false;
    public bool Obs_is_Vertical;
    public bool Obs_is_Horizontal;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = posB.position;
    }


    void FixedUpdate()
    {
        if (!waiting)
        {
            MoveObstacle();
        }
    }


    private void MoveObstacle()
    {

        Vector2 direction = (targetPos - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, targetPos);
        if (Obs_is_Vertical)
        {
            velocity = new Vector2(rb.velocity.x, direction.y * speed*Time.deltaTime);
        }
        if (Obs_is_Horizontal)
        {
            velocity = new Vector2(direction.x * speed, rb.velocity.y*Time.deltaTime);
        }
        rb.velocity = velocity;
        if (distance < 0.1f) SwitchTarget();


    }

    private void SwitchTarget()
    {
        if (targetPos == posA.position)
        {
            targetPos = posB.position;
        }
        else
        {
            targetPos = posA.position;
        }

        StartCoroutine(WaitAndMove(waitDuration));

    }

    private IEnumerator WaitAndMove(float duration)
    {
        waiting = true;
        rb.velocity = Vector2.zero; // Stop the movement while waiting
        yield return new WaitForSeconds(duration);

        waiting = false;
    }


}
