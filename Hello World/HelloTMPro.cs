using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelloTMPro : MonoBehaviour
{
    public TMP_Text helloText; //Text object.

    void Start()
    {
        helloText.text = "Hello World"; //Set the text object's text to Hello World.
    }
}
