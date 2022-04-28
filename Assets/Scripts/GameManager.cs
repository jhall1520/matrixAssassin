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
    private bool takeLife;

    // Start is called before the first frame update
    void Start()
    {
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

    public void moveToLevel2() {
        SceneManager.LoadScene("level2");
    }

    public void loseLife() {
        if (takeLife == true) {
            takeLife = false;
            lives--;
            livesShown.text = "x" + lives;
            if (lives == 0) {
                Reset();
                SceneManager.LoadScene("loseScene");
            } else {
                SceneManager.LoadScene(level);
            }
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



}
