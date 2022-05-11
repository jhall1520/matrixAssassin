using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public GameObject enemyObject;
    public Animator animator;
    public float attackRange;
    public LayerMask playerLayer;
    public Transform player;
    public Transform attackPoint;
    public float attackSpeed;
    public GameObject projectile;
    public bool isBoss;

    private bool inAttackRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, attackPoint.position) < attackRange) {

            animator.SetBool("shoot", false);
            attackSpeed -= Time.deltaTime;

            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

            if (attackSpeed <= 0) {
                animator.SetBool("shoot", true);
                if (isBoss)
                    attackSpeed = .3f;
                else
                    attackSpeed = 2f;
                Shoot();
            }
        }
    }

    void Shoot() {
        Transform projectileTransform = Instantiate(projectile.transform, attackPoint.position, projectile.transform.rotation);
        Vector3 direction = (player.position - attackPoint.position).normalized;
        projectileTransform.GetComponent<projectile>().initiate(direction, attackRange, isBoss);
        
    }

    public void killed() {
        animator.SetBool("dead", true);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        StartCoroutine(destroyEnemy());
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            // FindObjectOfType<GameManager>().loseLife();
        }
    }

    IEnumerator destroyEnemy() {
        yield return new WaitForSeconds(1);
        Destroy(transform.parent.gameObject);
    }
}
