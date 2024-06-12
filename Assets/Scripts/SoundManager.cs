using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] SoundTracks;
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(AS.isPlaying == false)
        {
            int LastAudioID=0;
            int AudioID;
            AudioID = SoundTracks.Length - 1;
            
            if(AudioID != LastAudioID)
            {
                AS.clip = SoundTracks[Random.Range(0, AudioID)];

                AS.Play();

                LastAudioID = AudioID;
            }
        }
    }
}
