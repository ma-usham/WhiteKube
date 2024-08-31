using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second
    public float minRotation = -10f; // Minimum rotation angle
   public float maxRotation = 10f;  // Maximum rotation angle

    void LateUpdate()
    {
        // Calculate the rotation amount using PingPong for smooth oscillation
        float rotationAmount = Mathf.PingPong(Time.time * rotationSpeed, maxRotation - minRotation) + minRotation;

        // Apply the rotation around the Z-axis
        transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
    }
}

