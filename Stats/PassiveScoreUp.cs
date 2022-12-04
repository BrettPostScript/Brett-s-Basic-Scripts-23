using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicScore))]
public class PassiveScoreUp : MonoBehaviour
{
    public float amount = 5f; //Amount to increase each second.
    BasicScore score; //Holder for the BasicScore reference.

    void Start()
    {
        score = GetComponent<BasicScore>(); //Get BasicScore.
    }

    void Update()
    {
        score.Score(amount * Time.deltaTime); //Increase score by the amount each second.
    }
}
