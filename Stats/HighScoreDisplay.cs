using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public string scoreType = "High Score: "; //Highscore label prefix.
    public TMP_Text scoreText; //Highscore text object.
    string highScoreKey = "highscore"; //Key to save the highscore.

    void Update()
    {
        if (scoreText) //If text object specified.
            scoreText.text = scoreType + (int)PlayerPrefs.GetFloat(highScoreKey, 0f); //Update highscore text.
    }
}
