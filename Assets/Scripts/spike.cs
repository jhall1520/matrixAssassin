using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        // if player collides with the spike
        if (other.tag == "Player") {
            // get animator
            Animator playerAnimator = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
            // fire animation
            playerAnimator.SetBool("isDead", true);
            // lose life
            FindObjectOfType<GameManager>().loseLife(playerAnimator);
        }
    }
}
