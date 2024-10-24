using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public Transform centerPoint; // The object will rotate around this point
    public float radius = 5f; // Radius of the circular path
    public float rotationSpeed = 2f; // Speed of rotation (in radians per second)

    public float startingAngle = 0f; // Starting angle

    void Update()
    {
        // Update the angle based on time and speed
        startingAngle += rotationSpeed * Time.deltaTime;

        // Calculate new position based on sine and cosine
        float x = centerPoint.position.x + Mathf.Cos(startingAngle) * radius;
        float y = centerPoint.position.y + Mathf.Sin(startingAngle) * radius;

        // Set the object's position
        transform.position = new Vector2(x, y);
    }
}

