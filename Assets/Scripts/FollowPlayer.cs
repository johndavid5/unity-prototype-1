using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // NOTE: this.player is magically initialized to point to the vehicle via the IDE
    // by dragging the vehicle to the FollowPlayer::Player field in the Main Camera.
    // See lesson 1.3.3 in https://learn.unity.com/tutorial/1-3-make-the-camera-follow-the-vehicle-with-variables
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"FollowPlayer::constructor(): this.player = {this.player}...");
    }

    // Update is called once per frame
    void Update()
    {
        // Assign camera's position to player's position...
        this.transform.position = this.player.transform.position;
    }
}
