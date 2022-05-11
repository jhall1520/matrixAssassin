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
        SceneManager.LoadScene(level);
    }

    public void loseLife() {
        // if player is not in the tutorial, lose life
        if (livesShown != null) {
            if (takeLife == true) {
                takeLife = false;
                lives--;
                livesShown.text = "x" + lives;
                if (lives == 0) {
                    Reset();
                    Time.timeScale = 1f;
                    SceneManager.LoadScene("loseScene");
                } else {
                    Time.timeScale = 1f;
                    // if player has not passed a checkpoint on this level
                    if (!passedCheckPoint)
                    // reload the scene
                        SceneManager.LoadScene(level);
                    else
                    // if the player has passed a checkpoint, respawn the player there
                        StartCoroutine(spawnAtCheckpoint());
                }
            }
        // if player is in tutorial, just reload the level
        } else {
            Time.timeScale = 1f;
            platformCollider.jumpedPlatform = false;
            SceneManager.LoadScene(level);
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

    IEnumerator spawnAtCheckpoint() {
        PlayerMovement.isDisabled = true;
        yield return new WaitForSeconds(.2f);
        Vector3 location = checkPoint.transform.position;
        location.x += 1;
        player.transform.position = location;
        player.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(.2f);
        PlayerMovement.isDisabled = false;
    }

}
