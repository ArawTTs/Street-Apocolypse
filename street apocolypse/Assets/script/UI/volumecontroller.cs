using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumecontroller : MonoBehaviour
{
    [SerializeField] private Slider volumeslider = null;

    private void start()
    {
        LoadValues();
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeslider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeslider.value = volumeValue;
        AudioListener.volume = volumeValue; 
    }
}
