using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObject : MonoBehaviour
{
    //This class maintains 1 instance of this object throughout various scenes.

    private static KeepObject target; //Holder for this object's identity.

    void Start()
    {
        DontDestroyOnLoad(this); //Set this object to keep between scenes.

        if (target == null) //If there is no other object instance.
            target = this; //Make this the object.
        else
            Destroy(gameObject); //Otherwise, destroy this object.
    }
}
