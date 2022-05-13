using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCollider : MonoBehaviour
{
    public static bool jumpedPlatform = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            jumpedPlatform = true;
        }
    }
}
