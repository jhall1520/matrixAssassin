using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingPlatform : MonoBehaviour
{

    public GameObject playerObject;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            playerObject.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerObject.transform.parent = null;
        }
    }
}
