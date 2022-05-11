using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public MeshRenderer flagMesh;
    public Material red;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            flagMesh.material = red;
            GameManager.passedCheckPoint = true;
        }
    }
}
