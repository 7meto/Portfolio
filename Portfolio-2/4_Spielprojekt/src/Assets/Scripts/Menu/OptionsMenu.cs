using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0);
        volumeSlider.value = savedVolume;  
        SetVolume(savedVolume); 
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume); 
        PlayerPrefs.Save(); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Return()
    {
        SceneTracker previousScene = FindObjectOfType<SceneTracker>();
        previousScene.ReturnToPreviousScene();
    }
}
