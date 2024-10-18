using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // A public GameObject, the player, target of the camera.
    public GameObject player;
    // A private offset, from the player to the camera.
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        // We use Start() to initialize the offset.
        // This takes the initial position of the camera 
        // (note that we can use this initialization because originally the player is at the origin).
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // We modify the position of the camera (through its transform, 
        // directly accessible through the variable transform), 
        // by adding the offset to the position of the player.
        transform.position = player.transform.position + offset;
    }
}
// LateUpdate() is the appropriate place for follow cameras,
// procedural animations, and gathering last known states.