using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float rotate;
    public bool userOffsetValues;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;

    public static bool inverted = false;
    // Start is called before the first frame update
    void Start()
    {
        // if (!userOffsetValues) {
        //     offset = player.position - transform.position;
        // }
        pivot.transform.position = player.transform.position;
        //pivot.transform.parent = player.transform;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!pause.isGamePause) {
        pivot.transform.position = player.transform.position;

        // rotates player when player moves
        float horizontal = Input.GetAxis("Mouse X") * rotate;
        pivot.Rotate(0, horizontal, 0);

        // rotates pivot left and right
        float vertical = Input.GetAxis("Mouse Y") * rotate;
        if (inverted) {
            pivot.Rotate(vertical, 0, 0);
        } else {
            pivot.Rotate(-vertical, 0, 0);
        }
    
       // Limit vertical camera
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f) {
            pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
        }

        if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
            pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, pivot.eulerAngles.y, 0.0f);
        }

        // moves camera based on players rotation
        float angleY = pivot.eulerAngles.y;
        float angleX = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(-angleX, angleY, 0);
        transform.position = player.position - (rotation * offset);
        // moves camera with player
        //transform.position = player.position - offset;

        if (transform.position.y < player.position.y) {
            transform.position = new Vector3(transform.position.x, player.position.y - .5f, transform.position.z);
        }
        transform.LookAt(player);
        }
    }
}
