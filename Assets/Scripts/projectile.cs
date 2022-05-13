using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class projectile : MonoBehaviour
{
    // variables
    private Vector3 shootDirection;
    private float attackRange;
    private Vector3 startPosition;
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        // position where the projectile spawned in at
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if the projectile is still in the attackRange
        if (Vector3.Distance(transform.position, startPosition) < attackRange)
            // move the projectile forward
            transform.position += shootDirection * speed * Time.deltaTime;

        // if the projectile leaves the attackRange
        else
            // destroy projectile
            Destroy(gameObject);
        
        // constantly rotates the projectile
        transform.Rotate(new Vector3(0, 0, 5 * 0.1f));
    }

    // initializes the projectile
    public void initiate(Vector3 direction, float attackRange) {
        shootDirection = direction;
        this.attackRange = attackRange;
        this.speed = 5;
    }

    private void OnTriggerEnter(Collider other) {
        // if collides with player
        if (other.tag == "Player") {
            // get animator
            Animator playerAnimator = other.gameObject.transform.GetChild(0).GetComponent<Animator>();
            // fire animation
            playerAnimator.SetBool("isDead", true);
            // player loses a life
            FindObjectOfType<GameManager>().loseLife(playerAnimator);
        }
    }
}
