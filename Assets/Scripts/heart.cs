using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public AudioSource pickUp;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.tag == "Player") {
            FindObjectOfType<GameManager>().gainLife();
            pickUp.Play();
            Destroy(this.gameObject);
        }
    }
}
