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
        SceneManager.LoadScene("level1");

    }

    public void MainMenu() {
        SceneManager.LoadScene("mainMenu");
    }
}
