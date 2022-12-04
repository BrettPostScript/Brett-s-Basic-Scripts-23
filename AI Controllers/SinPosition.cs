using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinPosition : MonoBehaviour
{
    public Vector3 dir; //The degrees the object oscillates its position on the x,y,z axis.
    public float speed = 1f; //how fast the object oscillates its position (1 is 1 second, 2 is half a second, etc).
    Vector3 initialPos; //captures the starting position for initilization purposes.
    public bool stationary = true; //If you intend to move the object in the level, make this false.

    private void Start()
    {
        initialPos = transform.position; //get start position of object.
    }

    void Update()
    {
        if (!stationary)
            transform.position += dir * Mathf.Sin(Time.time * speed); //use a small dir for this mode.
        else
            transform.position = initialPos + dir * Mathf.Sin(Time.time * speed); //standard bob position.
    }
}
