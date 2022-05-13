using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    // sound when heart is picked up
    public AudioSource pickUp;

    private void OnTriggerEnter(Collider other) {
        // if player collides
        if (other.tag == "Player") {
            // give the player another life
            FindObjectOfType<GameManager>().gainLife();
            // play sound
            pickUp.Play();
            // destroy extra life object
            Destroy(this.gameObject);
        }
    }
}
