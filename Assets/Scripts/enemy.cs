using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    // variables
    public GameObject enemyObject;
    public Animator animator;
    public float attackRange;
    public LayerMask playerLayer;
    public Transform player;
    public Transform attackPoint;
    public float attackSpeed;
    public GameObject projectile;

    public AudioSource projectileSound;

    // Update is called once per frame
    void Update()
    {
        // if the player is inside the attackRange
        if (Vector3.Distance(player.position, attackPoint.position) < attackRange) {
            // set Shoot to false
            animator.SetBool("shoot", false);
            // decrement attackSpeed
            attackSpeed -= Time.deltaTime;

            // rotation the enemy will do to look at player
            var lookPos = player.position - transform.position;
            // enemy won't look up at player
            lookPos.y = 0;
            // set the rotation
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

            // if it is time to attack
            if (attackSpeed <= 0) {
                // activate animation
                animator.SetBool("shoot", true);
                // reset timer
                attackSpeed = 2f;
                // shoot
                Shoot();
            }
        }
    }

    void Shoot() {
        // play sound
        projectileSound.Play();
        // spawn the projectile
        Transform projectileTransform = Instantiate(projectile.transform, attackPoint.position, projectile.transform.rotation);
        // find the players direction from the enemy
        Vector3 direction = (player.position - attackPoint.position).normalized;
        // fire the projectile at the player
        projectileTransform.GetComponent<projectile>().initiate(direction, attackRange);
        
    }

    public void killed() {
        // activate animation
        animator.SetBool("dead", true);
        // deactivate collider while animation is happening
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        // destroy enemy after animation
        StartCoroutine(destroyEnemy());
    }

    IEnumerator destroyEnemy() {
        // wait time
        yield return new WaitForSeconds(1);
        // destroy enemy
        Destroy(transform.parent.gameObject);
    }
}
