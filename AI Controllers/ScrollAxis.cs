using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAxis : MonoBehaviour
{
    public Vector3 axis; //The units to scroll an object along the x,y,z axis.

    void Update()
    {
        transform.position += axis * Time.deltaTime; //Scroll by 'x' units each second.
    }
}
