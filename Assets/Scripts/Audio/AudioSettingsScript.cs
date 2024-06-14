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
    public Slider effectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        float masterVolume;
        audioMixer.GetFloat("MasterVolume", out masterVolume);
        masterSlider.value = DBToLinear(masterVolume);

        float musicVolume;
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        musicSlider.value = DBToLinear(musicVolume);

        float effectsVolume;
        audioMixer.GetFloat("EffectsVolume", out effectsVolume);
        effectsSlider.value = DBToLinear(effectsVolume);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    public void SetMasterVolume(float sliderValue)
    {
        float dB = LinearToDB(sliderValue);
        audioMixer.SetFloat("MasterVolume", dB);
    }

    public void SetMusicVolume(float sliderValue)
    {
        float dB = LinearToDB(sliderValue);
        audioMixer.SetFloat("MusicVolume",dB);
    }

    public void SetEffectsVolume(float sliderValue)
    {
        float dB = LinearToDB(sliderValue);
        audioMixer.SetFloat("EffectsVolume",dB);
    }

    private float LinearToDB(float sliderValue)
    {
        return Mathf.Log10(sliderValue) * 20f+5f;
    }
    private float DBToLinear(float value)
    {
        return Mathf.Pow(10f, value / 20f);
    }

}