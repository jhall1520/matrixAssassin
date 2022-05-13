using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    // variables
    public static bool isInverted = false;
    public GameObject controlsToggle;
    // Start is called before the first frame update
    void Start()
    {
        // set toggle when first starting scene
        controlsToggle.GetComponent<Toggle>().isOn = isInverted;
    }

    // load main menu
    public void Menu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClick(bool tog) {
        // set static variable to the variable of the toggle
        isInverted = tog;
        // update camera setting for in game
        PlayerCamera.inverted = tog;
        
    }
}
