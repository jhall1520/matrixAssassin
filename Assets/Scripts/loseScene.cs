using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loseScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // unlock cursor from screen
        Cursor.lockState = CursorLockMode.None;
    }

    // load level1 scene
    public void Restart() {
        SceneManager.LoadScene("level1");

    }

    // go back to main menu
    public void MainMenu() {
        SceneManager.LoadScene("mainMenu");
    }
}
