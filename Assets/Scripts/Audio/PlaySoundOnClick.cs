using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlaySoundOnClick : MonoBehaviour
{

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
}