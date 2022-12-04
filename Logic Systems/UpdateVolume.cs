using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UpdateVolume : MonoBehaviour
{
    //This script updates the volume of an object's audio source based on which type of audio it is.
    
    AudioSource aSource; //Holds the audio source.
    public float defaultVolume = 1f; //Default volume (0 is silent, 1 is full volume).
    public enum AudioType { Music, UI, SFX }; //Enum for audio types.
    public AudioType audioType = AudioType.Music;

    private void Start()
    {
        aSource = GetComponent<AudioSource>(); //Get the audio source.
    }
    private void Update()
    {
        if (aSource)
            aSource.volume = PlayerPrefs.GetFloat(audioType.ToString() + "Volume", defaultVolume); //Update volume.
    }
}
