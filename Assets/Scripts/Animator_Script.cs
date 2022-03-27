using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Script : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public bool isJumping = false;
    public CharacterController player;
    public Animator animator;
    public int doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        this.player = GetComponent<CharacterController>();
        doubleJump = 0;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (player.isGrounded && Input.GetKey(KeyCode.W)) {
            animator.SetBool("isWalking", true);
        // } else if (Input.GetKey(KeyCode.A)) {
        //     animator.SetBool("isWalking", true );
        // } else if (Input.GetKey(KeyCode.D)) {
        //     animator.SetBool("isWalking", true);
        // } else if (Input.GetKey(KeyCode.S)) {
        //     animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }

        if (player.isGrounded && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0)) {
            animator.SetBool("isRunning", true);
        // } else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse0)) {
        //     animator.SetBool("isRunning", true );
        // } else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse0)) {
        //     animator.SetBool("isRunning", true);
        // } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse0)) {
        //     animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        // what to do here about jumping and double jumping
        if (player.isGrounded && Input.GetButtonDown("Jump") && doubleJump == 0) {
            animator.SetBool("isJumping", true);
            doubleJump = 1;
        } else if (!player.isGrounded && Input.GetButtonDown("Jump") && doubleJump == 1) {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJump", true);
            doubleJump = 0;
         } else if (player.isGrounded) {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJump", false);
         }
    }
}
