using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalSpawner : MonoBehaviour
{
    public float seconds = 1f; //Spawn interval in seconds.
    float secondsTimer; //Timer to keep track of frequency.
    public Vector3 range = new Vector3(10f, 0f, 10f); //The range around this object that objects can spawn on the x,y,z axis.
    public GameObject[] spawns; //Array of spawnable objects.

    void Update()
    {
        secondsTimer -= Time.deltaTime; //Handle frequency timer.
        if (secondsTimer <= 0f) //If it is time tp spawn a new object.
        {
            secondsTimer = seconds; //Reset the timer.
            //Spawn an object from the list within the range specified.
            if (spawns.Length > 0) //If there are objects to spawn.
                GameObject.Instantiate(spawns[Random.Range(0, spawns.Length)], transform.position + new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), Random.Range(-range.z, range.z)), gameObject.transform.rotation);
        }
    }
}
