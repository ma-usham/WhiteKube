using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObstacle : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 velocity;
    public Transform targetPos;
    private Rigidbody2D rb;
    private PlayerDeathCheck playerDeathCheck;
    private Vector2 startPos;
    public bool Obs_is_Vertical;
    public bool Obs_is_Horizontal;
    void Start()
    {
        playerDeathCheck = FindObjectOfType<PlayerDeathCheck>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (targetPos.position - transform.position).normalized;
        if (Obs_is_Vertical)
        {
            velocity = new Vector2(rb.velocity.x, direction.y * speed*Time.deltaTime);
        }
        if (Obs_is_Horizontal)
        {
            velocity = new Vector2(direction.x * speed*Time.deltaTime, rb.velocity.y);
        }
        rb.velocity = velocity;

        if (playerDeathCheck.isdead)
        {
            StartCoroutine(ResetPosition(playerDeathCheck.respawnTime));
        }
    }
    IEnumerator ResetPosition(float duration)
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(duration);
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }
}
