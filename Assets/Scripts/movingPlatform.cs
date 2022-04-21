using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingPlatform : MonoBehaviour
{

    public GameObject playerObject;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collided");
        if (other.tag == "Player") {
            Debug.Log("Player Collided");
            playerObject.transform.parent = transform;
        } else {
            Debug.Log("Not player");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerObject.transform.parent = null;
        }
    }
}
