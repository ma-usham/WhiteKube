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
    }

    private void Update()
    {
        // Find the closest player once per frame and rotate the gun towards it
        player = FindClosestPlayer();

        // Rotate towards player
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

    GameObject FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // If only one player exists, return it directly
        if (players.Length == 1)
        {
            return players[0];
        }

        GameObject closestPlayer = null;
        float shortestDistance = 10f;

        // Search for the closest player
        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }
}
