using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FadeLight : MonoBehaviour
{
    //This script fades out any color light without changing the color over time.
    //Pair this with a DelaySelfKill script and match the time in seconds for optimal effect.

    public float seconds; //The duration of the fade in seconds.
    Color startColor; //Holder for the starting color.
    Light l; //Holder for the current light source.

    void Start()
    {
        l = GetComponent<Light>(); //Get the light source.
        startColor = l.color; //Get the start color.
    }

    void Update()
    {
        //Fade to black for RGB at a rate relative to their starting values over the duration.
        l.color -= new Color((startColor.r * Time.deltaTime) / seconds, (startColor.g * Time.deltaTime) / seconds, (startColor.b * Time.deltaTime) / seconds);
    }
}
