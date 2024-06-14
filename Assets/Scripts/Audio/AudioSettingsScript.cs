using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        float masterVolume;
        audioMixer.GetFloat("MasterVolume", out masterVolume);
        masterSlider.value = Mathf.Pow(10, masterVolume / 20);

        float musicVolume;
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        musicSlider.value = Mathf.Pow(10, musicVolume / 20);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
}