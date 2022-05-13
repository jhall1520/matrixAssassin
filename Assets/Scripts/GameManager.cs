using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CharacterController player;
    public static int lives = 3;
    public static bool extraLifeRetrieved = false;
    public string level;
    public Text livesShown;
    public GameObject checkPoint;
    private bool takeLife;
    public static bool passedCheckPoint = false;

    public AudioSource die;
    public bool isSoundPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        if (livesShown != null)
            livesShown.text = "x" + lives;
        takeLife = true;

        if (extraLifeRetrieved)
            Destroy(FindObjectOfType<heart>().gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause.isGamePause) {
            Time.timeScale += (1f / 10f) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }

    public void moveToLevel(string level) {
        extraLifeRetrieved = false;
        SceneManager.LoadScene(level);
    }

    public void loseLife(Animator playerAnimator) {
    
        if (playerAnimator.GetBool("isDead")) {
            PlayerMovement.isDisabled = true;
            if (!isSoundPlaying)
                die.Play();
            isSoundPlaying = true;
        }
            // if player is not in the tutorial, lose life
        if (livesShown != null) {
            // if player has not already had a life taken yet
            if (takeLife == true) {
                // set life taken to false so, more than one life is not taken
                takeLife = false;
                // update lives and text
                lives--;
                livesShown.text = "x" + lives;
                // if lives reached zero, load Lose Scene
                if (lives == 0) {
                    // resets lives
                    Reset();
                    // resets time if player died in slow motion
                    Time.timeScale = 1f;
                    StartCoroutine(loadLoseScene());
                    // Else reload scene at the beggining or at the checkpoint
                } else {
                    // resets time if player died in slow motion
                    Time.timeScale = 1f;
                    // if player has not passed a checkpoint on this level
                    if (!passedCheckPoint) 
                    // reload the scene
                        StartCoroutine(reloadScene());
                    else {
                    // if the player has passed a checkpoint, respawn the player there
                        StartCoroutine(spawnAtCheckpoint(playerAnimator));
                        // life can be taken again after loading player at the checkpoint
                        isSoundPlaying = false;
                        takeLife = true;
                    }
                }
            }
        // if player is in tutorial, just reload the level
        } else {
            Time.timeScale = 1f;
            StartCoroutine(respawnTutorial(playerAnimator));
        }
    }

    public void gainLife() {
        lives++;
        extraLifeRetrieved = true;
        livesShown.text = "x" + lives;
    }

    public void slowMotion() {
        Time.timeScale = .1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    void Reset () {
     lives = 3;
    }

    IEnumerator spawnAtCheckpoint(Animator playerAnimator) {
        PlayerMovement.isDisabled = true;
        yield return new WaitForSeconds(1.75f);
        Vector3 location = checkPoint.transform.position;
        location.x += 1;
        location.y += 1;
        player.transform.position = location;
        player.transform.rotation = Quaternion.identity;
        playerAnimator.SetBool("isDead", false);
        yield return new WaitForSeconds(1.75f);
        PlayerMovement.isDisabled = false;
    }

    IEnumerator respawnTutorial(Animator playerAnimator) {
        PlayerMovement.isDisabled = true;
        yield return new WaitForSeconds(1.75f);
        playerAnimator.SetBool("isDead", false);
        Vector3 location = new Vector3(-0.35f, 0.6f, 31.27f);
        player.transform.position = location;
        player.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(.4f);
        PlayerMovement.isDisabled = false;
    }

    IEnumerator reloadScene() {
        yield return new WaitForSeconds(2f);
        PlayerMovement.isDisabled = false;
        SceneManager.LoadScene(level);
    }

    IEnumerator loadLoseScene() {
        yield return new WaitForSeconds(2f);
        PlayerMovement.isDisabled = false;
        SceneManager.LoadScene("loseScene");
    }

}
