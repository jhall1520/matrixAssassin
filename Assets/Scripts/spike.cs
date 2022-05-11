using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            FindObjectOfType<GameManager>().loseLife();
        }
    }
}
