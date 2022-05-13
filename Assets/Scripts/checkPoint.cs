using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    // MeshRenderer of the flag (checkpoint)
    public MeshRenderer flagMesh;
    // Color it will change to when player passes it
    public Material red;
    // Sound that will happen when player passes it
    public AudioSource checkpointSound;
    private static bool hasSoundPlayer = false;

    private void OnTriggerEnter(Collider other) {
        // if player collides with checkpoint
        if (other.tag == "Player") {
            // change flag color
            flagMesh.material = red;
            // if this is the first time
            if (!hasSoundPlayer) {
                hasSoundPlayer = true;
                // play the checkpoint sound
                checkpointSound.Play();
            }
            // let the GameManager know that the checkpoint has been passed
            GameManager.passedCheckPoint = true;
        }
    }
}
