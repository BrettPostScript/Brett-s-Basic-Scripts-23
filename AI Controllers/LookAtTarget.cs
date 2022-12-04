using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public string targetTag = "Player"; //Target to look for, should be "Player" by default.
    GameObject target; //Holder for the target once captured.
    public bool includeHeight; //Mark this as true if you want the AI to tilt up/down to target areas of elevation.

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag); //Get the target gameObject by its tag.
    }

    void Update()
    {
        if(target) //If target != null, always look at target.
            if (!includeHeight)
                transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            else
                transform.LookAt(target.transform.position);

    }
}
