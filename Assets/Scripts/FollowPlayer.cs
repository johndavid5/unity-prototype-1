using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
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
