using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCollider : MonoBehaviour
{
    public static bool jumpedPlatform = false;
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
            Debug.Log("made it");
            jumpedPlatform = true;
        }
    }
}