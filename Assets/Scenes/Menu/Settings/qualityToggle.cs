using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class qualityToggle : MonoBehaviour
{

    [SerializeField] Toggle isFullCheckBox;
    [SerializeField] Dropdown dropDown;

    [SerializeField] Dropdown resolutionDropdown;
    Resolution[] resolutions;
    int currentReso = 0;

    void Start()
    {

        int qlty = PlayerPrefs.GetInt("Quality", 2);

        dropDown.value = qlty;

        if (Screen.fullScreen)
        {
            isFullCheckBox.isOn = true;
        }
        else
        {
            isFullCheckBox.isOn = false;
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentReso = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentReso;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
        PlayerPrefs.SetInt("Quality", quality);

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool full)
    {
        Screen.fullScreen = full;
    }
}