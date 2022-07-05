using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class soundToggle : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] Text percentage;
    [SerializeField] Slider theSlider;
    [SerializeField] string whichSound = "General Volume";


    void Start()
    {
        theSlider.value = PlayerPrefs.GetFloat("volume " + whichSound, 1f);
        percentage.text = (int)mapToPerce(theSlider.value, -40, 5) + "%";
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat(whichSound, vol);
        percentage.text = (int)mapToPerce(vol, -50, 5) + "%";
        PlayerPrefs.SetFloat("volume " + whichSound, vol);
    }

    static float mapToPerce(float value, float min, float max)
    {
        return ((value - min) * 1f / (max - min)) * 100;
    }
}
