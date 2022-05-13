using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    // texts
    public GameObject[] texts;
    public GameObject firstPlatform;
    public GameObject secondPlatform;
    public GameObject closeOffFirstPlat;
    public GameObject closeOffSecondPlat;
    public GameObject enemies;
    public enemy[] aliveEnemies;
    
    // enemies
    public Transform[] spawnLocations;
    private bool spawnedEnemies = false;
    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // hide enemies
        enemies.SetActive(false);
        // close of the first playform
        closeOffFirstPlat.SetActive(true);
        // hide the second platform
        secondPlatform.SetActive(false);
        // hide close off for second platform
        closeOffSecondPlat.SetActive(false);
        
        // iterate through texts and set them to false except the first one
        for (int i = 0; i < texts.Length; i++) {
            if (i == 0) {
                texts[i].SetActive(true);
            } else {
                texts[i].SetActive(false);
            }
        }
    
    }

    void Update() {
        // sends player through commands on how to play the game
        switch (index) {
        case 0:
            if (Input.GetKeyDown(KeyCode.W)) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
            }
            break;
        case 1:
            if (Input.GetKeyDown(KeyCode.S)) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
            }
            break;
        case 2:
            if (Input.GetKeyDown(KeyCode.D)) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
            }
            break;
        case 3:
            if (Input.GetKeyDown(KeyCode.A)) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
            }
            break;
        case 4:
            StartCoroutine(lookAround());
            break;
        case 5:
            if (Input.GetButtonDown("Jump")) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
                secondPlatform.SetActive(true);
                closeOffFirstPlat.SetActive(false);
            }
            break;
        case 6:
            if (platformCollider.jumpedPlatform) {
                closeOffSecondPlat.SetActive(true);
                firstPlatform.SetActive(false);
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
            }
            break;
        case 7:
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
                enemies.SetActive(true);
            }
            break;
        case 8:
            if (Input.GetKeyDown(KeyCode.Q)) {
                texts[index].SetActive(false);
                index++;
                texts[index].SetActive(true);
                spawnedEnemies = true;
            }
            break;
        }
        // if enemies are active
        if (spawnedEnemies) {
            // get all enemies
            aliveEnemies = FindObjectsOfType<enemy>();
            // if none are shown
            if (aliveEnemies.Length == 0) {
                // player beat the tutorial
                SceneManager.LoadScene("TutorialWinScene");
            }
        }
    }

    IEnumerator lookAround() {
        yield return new WaitForSeconds(4);
        if (index == 4) {
            texts[index].SetActive(false);
            index++;
            texts[index].SetActive(true);
        }
    }

}
