using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // variables
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
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public static bool isDisabled = false;

    // sounds
    public AudioSource swingSword;
    public AudioSource falling;
    public AudioSource jumpSound;
    public AudioSource slowTime;

    // Start is called before the first frame update
    void Start()
    {
        // get player and gamemanager
        this.player = GetComponent<CharacterController>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if characterController is not disabled
        if (!isDisabled) { 
            // if player clicks the left mouse button
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                // iniated animation
                animator.SetBool("isSlash", true);
                // play sound
                swingSword.Play();
                // attack
                Attack();
            } else {
                // stop animation
                animator.SetBool("isSlash", false);
            }

            // if the player clicks Q
            if (Input.GetKeyDown(KeyCode.Q)) {
                // play sound
                slowTime.Play();
                // slow down time
                gameManager.slowMotion();
            }
            
            // if player is moving
            if ((Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))) > 0)
                // fire animation
                animator.SetFloat("speed", 1);
            else
                // stop animation
                animator.SetFloat("speed", 0);

            // players y position
            float y = moveDirection.y;
            // update x and z
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            // normalize values then multiply by players speed
            moveDirection = moveDirection.normalized * moveSpeed;
            // update with players y values
            moveDirection.y = y;

            // if player is on the ground
            if (player.isGrounded) {
                // fire animation
                animator.SetBool("isGrounded", true);
                // set y value
                moveDirection.y = 0f;

                // if player presses spacebar
                if (Input.GetButtonDown("Jump")) {
                    // fire animation
                    animator.SetBool("isGrounded", false);
                    // play sound
                    jumpSound.Play();
                    // update y
                    moveDirection.y = jump;
                }
            }

            // update y with physics and gravity
            moveDirection.y += Physics.gravity.y * gravityScale;
            
            // move player based on fps
            player.Move(moveDirection * Time.deltaTime);

            // if player starts to fall
            if (player.transform.position.y <= -5 && !animator.GetBool("isFalling")) {
                // fire animation
                animator.SetBool("isFalling", true);
                // play sound
                falling.Play();
            }
            
            // when player reaches a certain point while falling
            if (player.transform.position.y <= -200) {
                // stop animation
                animator.SetBool("isFalling", false);
                // player is dead and loses a life
                gameManager.loseLife(animator);
            }

            // Move player in different directions based on camera look direction
            if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0)) {
                transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotationSpeed);
            }
        }
    
    }

    void Attack() {
        // get all enemies in attackRange when button is pressed
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        
        // iterate through all enemies
        foreach(Collider enemy in hitEnemies) {
            // destroy enemy
            enemy.GetComponent<enemy>().killed();
        }
    }

    // draws the Sphere in the Editor
    // used in the Attack() method
    void OnDrawGizmos() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
