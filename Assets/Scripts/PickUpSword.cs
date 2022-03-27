using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
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
            FindObjectOfType<GameManager>().moveToLevel2();
        }
    }
}
