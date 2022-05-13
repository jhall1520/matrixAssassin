using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCollider : MonoBehaviour
{
    // if platform has been collided with
    public static bool jumpedPlatform = false;

    private void OnTriggerEnter(Collider other) {
        // if collided with player
        if (other.tag == "Player") {
            // update bool variable to true
            jumpedPlatform = true;
        }
    }
}
