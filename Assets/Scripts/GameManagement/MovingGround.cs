using System.Collections;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public float speed = 2f;
    public float waitDuration = 4f;
    private Vector2 targetPos;
    public Transform posA, posB;

    private bool waiting = false;
    public Rigidbody2D playerRb;

    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        if (!waiting)
        {
           MoveGround();
        }
    }

    private void MoveGround()
    {
        
        float distance = Vector2.Distance(transform.position, targetPos);
        float step = speed * Time.deltaTime;

        if (step < distance)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, step / distance);
        }
        else
        {
            transform.position = targetPos;
            if (targetPos == (Vector2)posA.position)
            {
                targetPos = posB.position;
            }
            else
            {
                targetPos = posA.position;
            }
            StartCoroutine(WaitAndMove(waitDuration));
        }
    }

    private IEnumerator WaitAndMove(float duration)
    {
        waiting = true;
        yield return new WaitForSeconds(duration);
        waiting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            playerRb.interpolation = RigidbodyInterpolation2D.None;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            playerRb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }
}
