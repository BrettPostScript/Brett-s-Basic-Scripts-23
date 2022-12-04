using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    //This melee class is used to create a swinging motion to a game object when spawned like a bullet.

    Transform startTrans; //Holder for this object's default transform.
    public float swingSpeed = 5f; //speed at which the melee object swings.
    public float angle = 45f; //angle away from the attacker to begin at.

    void Start()
    {
        startTrans = transform; //Get start transform.
        startTrans.Rotate(transform.up * angle); //Rotate 'x' degrees to the right to start.
    }

    void Update()
    {
        startTrans.Rotate(transform.up * -(angle * 2f) * swingSpeed * Time.deltaTime); //do a full swing at the speed specified.
    }
}
