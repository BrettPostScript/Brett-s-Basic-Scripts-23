using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXOnStart : MonoBehaviour
{
    public AudioClip clip; //Clip to play.
    GameObject a; //Holds the game object we will search for.
    AudioSource aSource; //Holds the audio source of the above game object.
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("SFX"); //Get the audio source tagged as SFX.
        if (a) //If there is such an object in the scene.
        {
            aSource = a.GetComponent<AudioSource>(); //Get that object's audio source.
            aSource.PlayOneShot(clip); //Play the clip.
        }
    }
}
