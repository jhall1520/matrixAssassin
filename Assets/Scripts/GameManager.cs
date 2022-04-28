using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CharacterController player;
    public static int lives = 3;
    public string level;
    public Text livesShown;
    private bool takeLife;

    // Start is called before the first frame update
    void Start()
    {
        livesShown.text = "x" + lives;
        takeLife = true;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += (1f / 10f) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void moveToLevel2() {
        SceneManager.LoadScene("level2");
    }

    public void loseLife() {
        if (takeLife == true) {
            takeLife = false;
            lives--;
            Debug.Log("lost life");
            livesShown.text = "x" + lives;
            if (lives == 0) {
                Reset();
                SceneManager.LoadScene("loseScene");
            } else {
                SceneManager.LoadScene(level);
            }
        }
    }

    public void slowMotion() {
        Time.timeScale = .3f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    void Reset () {
     lives = 3;
    }



}
