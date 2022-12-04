using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinRotation : MonoBehaviour
{
    public Vector3 dir; //the degrees on the x,y,z axis that the object oscillates.
    public float speed = 1f; //how fast the object oscillates its rotation (1 is 1 second, 2 is half a second, etc).
    Quaternion initialRot; //captures the starting rotation for initilization purposes.

    void Start()
    {
        initialRot = transform.rotation; //get start rotation of object.
    }

    void Update()
    {
        //oscillate object rotation based on a sin function.
        transform.rotation = initialRot * Quaternion.Euler(dir * Mathf.Sin(Time.time * speed));
    }
}
