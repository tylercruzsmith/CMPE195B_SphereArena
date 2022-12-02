using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsScreen : MonoBehaviour
{
    public void Back() {
        SceneManager.LoadScene("MainMenu");
        //or "Name of Scene"
    }

    public void FullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
        print ("Screen view changed successfully");
    }

}
