using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jump;
    public float gravityScale;
    public CharacterController player;
    public Vector3 moveDirection;
    public float rotationSpeed;
    public Transform pivot;
    public Animator animator;
    public GameObject playerModel;
    public int levelNum;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        this.player = GetComponent<CharacterController>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKey(KeyCode.Q)) {
            gameManager.slowMotion();
        }

        if ((Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))) > 0)
            animator.SetFloat("speed", 1);
        else
            animator.SetFloat("speed", 0);
        
    
        float y = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = y;
        if (player.isGrounded) {
            animator.SetBool("isGrounded", true);
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump")) {
                animator.SetBool("isGrounded", false);
                moveDirection.y = jump;
            }
        }
        
        if (Input.GetKey(KeyCode.Mouse0))
            animator.SetBool("isSlash", true);
        else 
            animator.SetBool("isSlash", false);
        

        moveDirection.y += Physics.gravity.y * gravityScale;

        
        player.Move(moveDirection * Time.deltaTime);

        if (moveDirection.y <= -20) {
            gameManager.loseLife();
        }

        // Move player in different directions based on camera look direction
        if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0)) {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    
    }
}
