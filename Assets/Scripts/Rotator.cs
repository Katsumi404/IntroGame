using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its up axis at the specified speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
