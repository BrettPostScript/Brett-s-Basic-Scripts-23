using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxis : MonoBehaviour
{
    public Vector3 axis = new Vector3(15f, 15f, 15f); //The units to rotate the object along its axis.
    public bool isRandom; //Mark true if the object will begin with a random axis of rotation.

    private void Start()
    {
        if (isRandom) //Take the axis entered and select a random axis within that range.
            axis = new Vector3(Random.Range(-axis.x, axis.x), Random.Range(-axis.y, axis.y), Random.Range(-axis.z, axis.z));
    }

    void Update()
    {
        transform.Rotate(axis * Time.deltaTime); // rotate 'x' degrees each second.
    }
}
