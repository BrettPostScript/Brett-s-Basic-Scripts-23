using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    float alpha = 1f; //Overlay start opacity (1 is full).
    Texture2D tex; //Texture that will hold the fade overlay.
    public Color color; //Color of the fade.

    public void Start()
    {
        tex = new Texture2D(1, 1); //Initialize the fade overlay.
    }

    public void OnGUI()
    {
        alpha -= (Time.deltaTime / 2f); //Fade out over 2 seconds.
        if (alpha > 0f)
        {
            tex.SetPixel(0, 0, new Color(color.r, color.g, color.b, alpha)); //Set the color and fade alpha.
            tex.Apply();
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex); //Draw the texture.
        }
    }
}
