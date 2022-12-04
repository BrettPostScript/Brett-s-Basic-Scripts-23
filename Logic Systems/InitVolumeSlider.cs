using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class InitVolumeSlider : MonoBehaviour
{
    public float defaultVolume = 1f; //Default volume (0 is silent, 1 is full volume).
    public enum AudioType { Music, UI, SFX }; //Enum for audio types.
    public AudioType audioType = AudioType.Music;

    private void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(audioType.ToString() + "Volume", defaultVolume); //Init volume.
    }
}
