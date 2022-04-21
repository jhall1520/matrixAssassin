using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public GameObject enemyObject;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killed() {
        animator.SetBool("dead", true);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //FindObjectOfType<GameManager>().loseLife();
        }
    }
}
