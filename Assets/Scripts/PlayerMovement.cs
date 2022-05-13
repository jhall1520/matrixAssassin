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
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public static bool isDisabled = false;

    public AudioSource swingSword;
    public AudioSource die;
    public AudioSource falling;
    public AudioSource jumpSound;
    public AudioSource slowTime;



    // Start is called before the first frame update
    void Start()
    {
        
        this.player = GetComponent<CharacterController>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isDisabled) { 
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                animator.SetBool("isSlash", true);
                swingSword.Play();
                Attack();
            } else {
                animator.SetBool("isSlash", false);
            }


            if (Input.GetKeyDown(KeyCode.Q)) {
                slowTime.Play();
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
                    jumpSound.Play();
                    moveDirection.y = jump;
                }
            }

            moveDirection.y += Physics.gravity.y * gravityScale;
            
            player.Move(moveDirection * Time.deltaTime);

            if (player.transform.position.y <= -5 && !animator.GetBool("isFalling")) {
                animator.SetBool("isFalling", true);
                falling.Play();
            }
                
            if (player.transform.position.y <= -200) {
                animator.SetBool("isFalling", false);
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
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider enemy in hitEnemies) {
            enemy.GetComponent<enemy>().killed();
        }
    }

    void OnDrawGizmos() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
