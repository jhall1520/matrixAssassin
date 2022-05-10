using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    private float attackRange;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, startPosition) < attackRange)
            transform.position += shootDirection * 2 * Time.deltaTime;
        else
            Destroy(gameObject);
        
            //Destroy(this);
        // transform.Translate(Vector3.forward * 0.2 * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 5* 0.1f));
        //transform.rotation += Vector3.up * Time.deltaTime * 0.5f;
    }

    public void initiate(Vector3 direction, float attackRange) {
        shootDirection = direction;
        this.attackRange = attackRange;
    }

    // public void initiate(Vector3 direction, float attackRange) {
    //     shootDirection = direction;
    //     this.attackRange = attackRange;
    // }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            FindObjectOfType<GameManager>().loseLife();
        }
    }
}
