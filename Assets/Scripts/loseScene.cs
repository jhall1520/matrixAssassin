using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loseScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        Debug.Log("level1");
        SceneManager.LoadScene("level1");

    }

    public void MainMenu() {
        Debug.Log("mainMenu");
        SceneManager.LoadScene("mainMenu");
    }
}
