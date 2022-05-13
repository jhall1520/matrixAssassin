using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingPlatform : MonoBehaviour
{
    // player
    public GameObject playerObject;

    private void OnTriggerEnter(Collider other) {
        // if player collides with platform
        if (other.tag == "Player")
            // make the player object the child of the platfrom object
            playerObject.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other) {
        // when player jumps or stops touching the platform
        if (other.tag == "Player") {
            // set the parent object of the player to null
            playerObject.transform.parent = null;
        }
    }
}
