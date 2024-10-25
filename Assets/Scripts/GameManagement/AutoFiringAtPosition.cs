using UnityEngine;

public class AutoFiringAtPosition : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 1f;
    public float bulletInterval = 1f;
    private float initialBulletInterval;
    public float bulletLifetime = 5f;

    [Header("Target Object")]
    public GameObject targetObject; // Assign the target GameObject from the inspector
    

    private void Start()
    {
        initialBulletInterval = bulletInterval;
    }

    private void FixedUpdate()
    {
        bulletInterval -= Time.fixedDeltaTime;

        if (bulletInterval <= 0f)
        {
            FireAtTargetObject(); // Fire at the specified target object
            bulletInterval = initialBulletInterval;
        }
    }

    // Fire a bullet towards the position of the target GameObject
    void FireAtTargetObject()
    {
        if (targetObject != null)
        {
            Vector2 targetPosition = targetObject.transform.position;
            Vector2 direction = (targetPosition - (Vector2)firePoint.position).normalized;

            // Trigger firing animation
           

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed * Time.deltaTime;

            Destroy(bullet, bulletLifetime);
        }
        else
        {
            Debug.LogWarning("Target object not assigned!");
        }
    }
}
