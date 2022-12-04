using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicScore : MonoBehaviour
{
    float currentScore; //Holder for the current score.
    string highScoreKey = "highscore"; //Key to save the highscore.
    public bool logHighScore; //Mark as true to log the highscore upon kill or scene change.

    //Increase current score by num.
    public void Score(float num)
    {
        currentScore += num;
        if (currentScore < 0f)
            currentScore = 0f;
    }

    //Log the highscore if current score is higher than the current highscore.
    public void LogHighScore()
    {
        if (currentScore > PlayerPrefs.GetFloat(highScoreKey, 0f))
            PlayerPrefs.SetFloat(highScoreKey, currentScore);
    }

    //Get the current score.
    public float GetCurrent()
    {
        return currentScore;
    }

    //Log the high score when this object is destroyed if logHighScore is true.
    public void OnDestroy()
    {
        if(logHighScore)
            LogHighScore();
    }
}
