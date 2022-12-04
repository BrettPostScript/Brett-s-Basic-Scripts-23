using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnClick : MonoBehaviour
{
    public float score; //Holds the score increase amount.
    BasicScore basicScore; //Holder for the scene's basic score object.

    void Start()
    {
        basicScore = GameObject.FindObjectOfType<BasicScore>(); //Find 1 basic score object in the scene.
    }
    void OnMouseDown()
    {
        if (basicScore) //If such an object exists.
            basicScore.Score(score); //Increase that object's score.
    }
}
