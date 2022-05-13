using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Animator playerAnimator = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
            playerAnimator.SetBool("isDead", true);
            FindObjectOfType<GameManager>().loseLife(playerAnimator);
        }
    }
}
