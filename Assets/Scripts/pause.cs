using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public static bool isGamePause = false;
    public GameObject pauseMenu;

    void Start() {
        // pauseMenu is not active at the begining of scenes
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // if esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            // if game is paused
            if (isGamePause) {
                // resume game
                Resume();
            // if not paused
            } else {
                // pause game
                Pause();
            }
        }
        
    }

    public void Resume() {
        // lock the cursor back to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // hide the pause menu
        pauseMenu.SetActive(false);
        // game time will start normal time
        Time.timeScale = 1f;
        // update bool
        isGamePause = false;
    }

    public void Pause() {
        // unlock cursor
        Cursor.lockState = CursorLockMode.None;
        // show pause screen
        pauseMenu.SetActive(true);
        // pauses game while pause menu is up
        Time.timeScale = 0f;
        // update bool
        isGamePause = true;
    }

    public void GoToMenu() {
        // hide pause menu
        pauseMenu.SetActive(false);
        // game time will start as normal
        Time.timeScale = 1f;
        // update bool
        isGamePause = false;
        // load main menu
        SceneManager.LoadScene("mainMenu");
    }
}
