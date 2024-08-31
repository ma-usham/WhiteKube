using System.Collections;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public Transform targetPos;
    public float gravity = 1;
    public float fallDelay = 1.0f; // Delay before the ground starts falling
    private float playerGravity;
    private bool isFalling;
    private PlayerDeathCheck playerDeathCheck;
    private Rigidbody2D rb;
    public bool isGround;
    public float stopThreshold = 0.1f; // Threshold to determine if the object has reached the target

    private Vector2 startPos;

    private void Awake()
    {
        playerDeathCheck = FindObjectOfType<PlayerDeathCheck>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
        //playerGravity = playerDeathCheck.rbplayer.gravityScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Start the delay before falling
            StartCoroutine(DelayFall(fallDelay));
            if(this.gameObject.layer == LayerMask.NameToLayer("Ground") && isGround)
            {
                collision.transform.SetParent(this.transform);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isGround && collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            //playerDeathCheck.rbplayer.gravityScale = playerGravity;
        }
    }

    private void FixedUpdate()
    {
        if (isFalling)
        {
            rb.gravityScale = gravity;

            // Check if the object is within the stopThreshold distance from the target position
            if (Mathf.Abs(transform.position.y - targetPos.position.y) < stopThreshold)
            {
                // Snap to the exact target position
                transform.position = new Vector2(transform.position.x, targetPos.position.y);

                // Stop further movement
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                rb.bodyType = RigidbodyType2D.Kinematic;

                if (this.tag == "Obstacles")
                {
                    this.tag = "Untagged";
                    this.gameObject.layer = LayerMask.NameToLayer("Ground");
                }

                isFalling = false;
            }
        }

        if (playerDeathCheck.isdead)
        {
            StartCoroutine(ResetPosition(playerDeathCheck.respawnTime));
        }
    }

    IEnumerator DelayFall(float delay)
    {
        yield return new WaitForSeconds(delay);
        isFalling = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = gravity;
    }

    IEnumerator ResetPosition(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        isFalling = false;

        if (!isGround)
        {
            this.tag = "Obstacles";
            this.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
