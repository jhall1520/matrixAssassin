using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public MeshRenderer flagMesh;
    public Material red;
    public AudioSource checkpointSound;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            flagMesh.material = red;
            checkpointSound.Play();
            GameManager.passedCheckPoint = true;
        }
    }
}
