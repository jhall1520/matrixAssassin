using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public static bool isInverted = false;
    public GameObject controlsToggle;
    // Start is called before the first frame update
    void Start()
    {
        controlsToggle.GetComponent<Toggle>().isOn = isInverted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClick(bool tog) {
        isInverted = tog;
        PlayerCamera.inverted = tog;
        
    }
}
