using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CharacterController player;
    public int lives;
    public string level;
    // Start is called before the first frame update
    void Start()
    {

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
        lives--;
        if (lives == 0) {
            SceneManager.LoadScene(level);
        } else {
            Vector3 moveDirection;
            moveDirection.x = 0;
            moveDirection.y = -1;
            moveDirection.z = 0;
            player.Move(moveDirection);
        }
    }

    public void slowMotion() {
        Time.timeScale = .3f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }



}
