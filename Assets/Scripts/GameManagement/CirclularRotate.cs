using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclularRotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Rotate the object around the Z-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
