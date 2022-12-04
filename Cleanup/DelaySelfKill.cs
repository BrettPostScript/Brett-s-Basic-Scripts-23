using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySelfKill : MonoBehaviour
{
    public float seconds = 1.5f; //Delay in seconds.

    void Update()
    {
        seconds -= Time.deltaTime; //Update timer.
        if (seconds <= 0f) //If timer has ended.
            Destroy(gameObject); //destroy this object after 'x' seconds.
    }
}
