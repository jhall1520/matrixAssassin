using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public string level1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {
        SceneManager.LoadScene(level1);

    }
    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit() {
        Debug.Log("User quit the application.");
        Application.Quit();
    }

}
