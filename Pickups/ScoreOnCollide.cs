using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnCollide : MonoBehaviour
{
    public float points = 1f; //Increase score by this amount.
    public bool selfDestruct = true; //Mark as true if this object destroys itself upon collision.
    public string restrictToTag = "Player"; //Specify a tag to limit to only objects with that tag (eg. Player).
    public bool searchForScore = false; //Mark as true to add to the only BasicScore object in the scene.
    BasicScore basicScore; //Holder for the scene's basic score object.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == restrictToTag || restrictToTag == "") //If there is no external score holder specified.
        {
            if (searchForScore == false)
                collision.gameObject.SendMessage("Score", points, SendMessageOptions.DontRequireReceiver); //Try to increase score.
            else
            {
                basicScore = GameObject.FindObjectOfType<BasicScore>(); //Find 1 basic score object in the scene.
                if (basicScore) //If such an object exists.
                    basicScore.Score(points); //Increase that object's score.
            }
            if (selfDestruct)
                Destroy(gameObject); //Destroy this object.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (searchForScore == false)
            other.gameObject.SendMessage("Score", points, SendMessageOptions.DontRequireReceiver); //Try to increase score.
        else
        {
            basicScore = GameObject.FindObjectOfType<BasicScore>(); //Find 1 basic score object in the scene.
            if (basicScore) //If such an object exists.
                basicScore.Score(points); //Increase that object's score.
        }
        if (selfDestruct)
            Destroy(gameObject); //Destroy this object.
    }
}
