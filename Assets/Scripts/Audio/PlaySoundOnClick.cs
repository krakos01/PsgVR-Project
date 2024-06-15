using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlaySoundOnClick : MonoBehaviour
{
    public static PlaySoundOnClick Instance {get; set;}

    public AudioClip clickSound;
    private AudioSource AS;

    void Start()
    {
        AS = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (clickSound != null)
        {
            AS.PlayOneShot(clickSound);
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}