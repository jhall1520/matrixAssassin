using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    // next level to go to
    public string goToLevel;

    private void OnTriggerEnter(Collider other) {
        // if player collides with sword piece
        if (other.tag == "Player") {
            // move to next level
            FindObjectOfType<GameManager>().moveToLevel(goToLevel);
    
        }
    }
}
