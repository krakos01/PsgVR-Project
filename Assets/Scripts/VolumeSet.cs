using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSet : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        SetMusicVolume();
        SetEffectsVolume();
        musicSlider.value = 10;
        effectsSlider.value = 10;
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    
    public void SetEffectsVolume()
    {
        float volume = effectsSlider.value;
        myMixer.SetFloat("Effects", Mathf.Log10(volume) * 20);
    }

}
