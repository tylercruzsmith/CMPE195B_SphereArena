using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("LoadingScreen");
        //or "Name of Scene"

    }

    public void Settings() {
        SceneManager.LoadScene("Settings");
        //or "Name of Scene"

    }

    public void Quit() {
        Application.Quit();
    }

}
