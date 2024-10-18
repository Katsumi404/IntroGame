using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem ;

public class PlayerController : MonoBehaviour
{
    // Public variable to capture movement input as a 2-dimensional vector
    public Vector2 moveValue;
    // Public variable for the speed of the player
    public float speed;

    // The OnMove function captures the input when the "Move" action is executed by the player.
    // This function is automatically called by Unity whenever the corresponding action is triggered.
    // Input can be captured from the WASD keys or the arrow keys.
    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    // FixedUpdate is used for physics-related calculations, as it runs at a fixed interval.
    // We create a vector that represents the direction the sphere should move based on the received input.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        // Apply a physics force to move the player. The force is based on the direction (movement),
        // multiplied by the speed and Time.fixedDeltaTime. 
        // This ensures consistent movement speed regardless of frame rate. 
        // Try removing Time.fixedDeltaTime to see the impact on movement.
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }
}
// You can check the meaning of any method by hovering your mouse over them in your code editor.