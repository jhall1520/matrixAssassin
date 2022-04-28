using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSwing : MonoBehaviour
{
    //public Transform ninjaStar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Debug.Log("Hit star");
            FindObjectOfType<GameManager>().loseLife();
        }
    }
}
