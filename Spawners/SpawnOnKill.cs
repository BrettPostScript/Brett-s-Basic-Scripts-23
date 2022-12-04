using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnKill : MonoBehaviour
{
    public GameObject[] spawns; //Array of spawnable objects.
    public Vector3 range = new Vector3(1f, 0, 1f); //The range around this object that objects can spawn on the x,y,z axis.
    public int num = 1; //Number of times to spawn an object from the list.

    public void Drop()
    {
        //Spawn an object from the list within the range specified.
        if (spawns.Length > 0) //If there are objects to spawn.
            for (int n = 0; n < num; n++) //'x' number of times.
            GameObject.Instantiate(spawns[Random.Range(0, spawns.Length)], transform.position + new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), Random.Range(-range.z, range.z)), gameObject.transform.rotation);
    }
}
