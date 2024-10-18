using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Public variable to capture movement input as a 2-dimensional vector
    public Vector2 moveValue;
    // Public variable for the speed of the player
    public float speed;

    private int count;
    private int numPickups = 8;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

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

    // OnTriggerEnter() is a function that is called when other game object’s collider, configured as a trigger, collides with the collider of the game object that has this script as a component (i.e., in this case, when a pick-up collider collides with the player’s collision).
    // We need to check if we are colliding with a pick-up. For this we check the tag of the game object.
    // If we are colliding with a pick-up, we set the game object to inactive.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count ++;
            SetCountText();
        }
    }

    private void SetCountText() 
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups) 
        {
            winText.text = "You win!";
        }
    }
}
// You can check the meaning of any method by hovering your mouse over them in your code editor.