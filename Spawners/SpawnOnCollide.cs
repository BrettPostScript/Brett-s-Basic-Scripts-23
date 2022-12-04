using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCollide : MonoBehaviour
{
    public GameObject spawn; //Object to spawn.
    public Transform target; //Position to spawn the object.

    void Start()
    {
        if (!target) //If no target is specified.
            target = gameObject.transform; //The target position becomes this object's position.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(spawn) //If there is an object to spawn.
            GameObject.Instantiate(spawn, target.position, gameObject.transform.rotation); //Spawn the object.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spawn) //If there is an object to spawn.
            GameObject.Instantiate(spawn, target.position, gameObject.transform.rotation); //Spawn the object.
    }
}
