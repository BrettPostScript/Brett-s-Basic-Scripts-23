using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioClip clip; //Clip to play.
    GameObject a; //Holds the game object we will search for.
    AudioSource aSource; //Holds the audio source of the above game object.

    void Start()
    {
        if (clip != null) //If a clip is added.
        {
            a = GameObject.FindGameObjectWithTag("Music"); //Get the audio source tagged as Music.
            if (a) //If there is such an object in the scene.
            {
                aSource = a.GetComponent<AudioSource>(); //Get that object's audio source.
                if (aSource.clip != clip) //If the new clip is different.
                {
                    aSource.clip = clip; //Change the clip.
                    aSource.Play(); //Play the new clip.
                }
            }
        }
    }
}
