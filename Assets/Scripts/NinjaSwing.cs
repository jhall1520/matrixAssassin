using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSwing : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        // if player collides
        if (other.tag == "Player") {
            // get animator
            Animator playerAnimator = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
            // play animation
            playerAnimator.SetBool("isDead", true);
            // take away one of the players lives
            FindObjectOfType<GameManager>().loseLife(playerAnimator);
        }
    }
}
