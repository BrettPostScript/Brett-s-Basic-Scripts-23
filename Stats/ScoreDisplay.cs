using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BasicScore))]
public class ScoreDisplay : MonoBehaviour
{
    public string scoreType = "Points: "; //Score label prefix.
    public TMP_Text scoreText; //Score text object.
    BasicScore score; //Holder for the BasicScore reference.

    void Start()
    {
        score = GetComponent<BasicScore>(); //Get BasicScore.
    }

    void Update()
    {
        if (scoreText) //If text object specified.
            scoreText.text = scoreType + (int)score.GetCurrent(); //Update score text.
    }
}
