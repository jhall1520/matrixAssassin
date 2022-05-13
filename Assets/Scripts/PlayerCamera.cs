using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // camera variables
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
    
        // pivot postion equals the players position at the start
        pivot.transform.position = player.transform.position;
        // pivot does not have a parent
        pivot.transform.parent = null;

        // lock cursor to the center of the scene
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if game is not paused
        if (!pause.isGamePause) {
            // update pivot position
            pivot.transform.position = player.transform.position;

            // rotates player when player moves mouse
            float horizontal = Input.GetAxis("Mouse X") * rotate;
            pivot.Rotate(0, horizontal, 0);

            // rotates pivot left and right
            float vertical = Input.GetAxis("Mouse Y") * rotate;

            // if inverted option is true
            if (inverted) {
                pivot.Rotate(vertical, 0, 0);
            // if inverted option is false
            } else {
                pivot.Rotate(-vertical, 0, 0);
            }
        
        // Limit vertical camera, so player cannot go under the ground with the camera and go over the players head
            if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f) {
                pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
            }

            if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
                pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, pivot.eulerAngles.y, 0.0f);
            }

            // moves camera based on players rotation
            float angleY = pivot.eulerAngles.y;
            float angleX = pivot.eulerAngles.x;

            // set rotation
            Quaternion rotation = Quaternion.Euler(-angleX, angleY, 0);
            transform.position = player.position - (rotation * offset);

            if (transform.position.y < player.position.y) {
                transform.position = new Vector3(transform.position.x, player.position.y - .5f, transform.position.z);
            }
            // have the camera look at the player
            transform.LookAt(player);
        }
    }
}
