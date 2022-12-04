using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadLookAtTarget : MonoBehaviour
{
    public string targetTag = "Player"; //Target to look for, should be "Player" by default.
    public float lookRange = 10f; //Radius range of AI senses.
    GameObject target; //Holder for the target once captured.
    public bool includeHeight; //Mark this as true if you want the AI to tilt up/down to target areas of elevation.

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag); //Get the target gameObject by its tag.
    }

    void Update()
    {
        if (target) //If target != null
            if (Vector3.Distance(transform.position, target.transform.position) < lookRange) //If within radius.
                if(Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out RaycastHit hit) && hit.collider.tag == targetTag) //If nothing is obscuring the target from view.
                    if (!includeHeight)
                        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                    else
                        transform.LookAt(target.transform.position);
    }
}
