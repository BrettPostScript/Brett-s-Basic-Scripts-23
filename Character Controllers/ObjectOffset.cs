using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOffset : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 10f, 0); //The positional offset from a target in units on the x,y,z axis.
    public GameObject target; //Holder for the target.
    public bool lookAt = true; //Mark as true if this object should always face the target.

    void Update()
    {
        if (target) //If target != null.
        {
            transform.position = target.transform.position + offset; //Offset this object's position.
            if (lookAt) //If lookAt is true, face the target.
                transform.LookAt(target.transform.position);
        }
    }
}
