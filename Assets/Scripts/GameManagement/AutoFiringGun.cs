using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFiringGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 1f;
    public float bulletInterval = 1f;
    private float initialBulletInterval;
    public float bulletLifetime = 5f;

    private GameObject player; // Cached player reference

    private void Start()
    {
        initialBulletInterval = bulletInterval;

        // Directly find and assign the player at the start
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Rotate towards the player
        if (player != null)
        {
            RotateTowardsPlayer(player);
        }
    }

    private void FixedUpdate()
    {
        bulletInterval -= Time.fixedDeltaTime; // Use fixedDeltaTime for consistent timing in FixedUpdate

        if (bulletInterval <= 0f)
        {
            FireAtPlayer(player);
            bulletInterval = initialBulletInterval;
        }
    }

    void FireAtPlayer(GameObject targetPlayer)
    {
        if (targetPlayer != null)
        {
            Vector2 direction = (targetPlayer.transform.position - firePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;

            // Destroy the bullet after a specified lifetime
            Destroy(bullet, bulletLifetime);
        }
    }

    void RotateTowardsPlayer(GameObject targetPlayer)
    {
        if (targetPlayer != null)
        {
            Vector2 direction = (targetPlayer.transform.position - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
