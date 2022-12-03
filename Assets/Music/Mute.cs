using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    Toggle myToggle;

    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        if(AudioListener.volume == 0)
        {
            myToggle.isOn = false;
        }
    }

    // Update is called once per frame
    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if (audioIn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
