using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] SoundTracks;
    private bool isWaitingForSoundtrack = false;
    private bool isFirstSoundtrack = true;
    private int LastAudioID = -1;
    private List<int> availableTracks;
    private AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        InitializeAvaibleTracks();
    }


    // Update is called once per frame
    void Update()
    {
        if (AS.isPlaying == false && isWaitingForSoundtrack == false)
        {
            if (isFirstSoundtrack)
            {
                StartCoroutine(PlaySoundtrackLater(1f));
                isFirstSoundtrack = false;
            }
            else
            { 
                StartCoroutine(PlaySoundtrackLater(10f)); 
            }
        }
    }

    private void InitializeAvaibleTracks()
    {
        availableTracks = new List<int>();
        for (int i = 0; i < SoundTracks.Length; i++)
        {
            availableTracks.Add(i);
        }
    }

    private void PlaySoundtrack()
    {
        if (LastAudioID != -1)
        {
            availableTracks.Remove(LastAudioID);
        }

        int randomID = Random.Range(0, availableTracks.Count);
        int AudioID = availableTracks[randomID];

        AS.clip = SoundTracks[AudioID];
        AS.Play();
        
        if (availableTracks.Count == 0)
        {
            InitializeAvaibleTracks();
        }
        availableTracks.Remove(AudioID);

        LastAudioID = AudioID;
    }

    private IEnumerator PlaySoundtrackLater(float delay)
    {
        isWaitingForSoundtrack = true;
        yield return new WaitForSeconds(delay);
        PlaySoundtrack();
        isWaitingForSoundtrack = false;
    }
}
