using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public string level;
    // Start is called before the first frame update
    void Start()
    {
        // unlock level from screen
        Cursor.lockState = CursorLockMode.None;
    }

    // load level
    public void Play() {
        SceneManager.LoadScene(level);

    }

    // load tutorial
    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    // load options
    public void Options() {
        SceneManager.LoadScene("OptionsScene");
    }

    // quit application
    public void Quit() {
        Debug.Log("User quit the application.");
        Application.Quit();
    }

}
