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
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            if (isGamePause) {
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    public void Resume() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        // game time will start as normal
        Time.timeScale = 1f;
        isGamePause = false;
    }

    public void Pause() {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        // pauses game while pause menu is up
        Time.timeScale = 0f;
        isGamePause = true;
    }

    public void GoToMenu() {
        pauseMenu.SetActive(false);
        // game time will start as normal
        Time.timeScale = 1f;
        isGamePause = false;
        SceneManager.LoadScene("mainMenu");
    }
}
