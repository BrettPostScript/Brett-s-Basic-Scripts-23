using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AIMover : MonoBehaviour
{
    float hInput; //Horizontal input (x axis).
    float vInput; //Vertical input (y or z axis, depending on topDown).
    Rigidbody rb; //Gets the rigidbody.
    public string targetTag = "Player"; //Target to look for, should be "Player" by default.
    GameObject target; //Holder for the target once captured.
    public float speed = 20f; //Movement speed applied to the rigidbody.
    public float turning; //Automatically turns the gameobject when moving (Mark as 0 to keep from turning).
    public bool topDown = true; //Mark as true to move object along the x,z axis.  Mark false for x,y axis movement.
    public bool lockVertical; //Mark true to ignore vertical inputs.
    public bool lockHorizontal; //Mark true to ignore horizontal inputs.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the rigidbody.
    }

    void Update()
    {
        FindTarget(); //Update the current target just in case the original is destroyed.
        if (target) //if target != null
        {
            Vector3 diff = (target.transform.position - transform.position).normalized; //get direction to target.
            //Get inputs for movement.
            if (!lockHorizontal)
                hInput = diff.x;
            if (!lockVertical && topDown)
                vInput = diff.z;
            if (!lockVertical && !topDown)
                vInput = diff.y;
            //Add force towards the target position.
            if (topDown)
                rb.AddForce(new Vector3(hInput, 0f, vInput) * speed * Time.deltaTime, ForceMode.VelocityChange);
            else
                rb.AddForce(new Vector3(hInput, vInput, 0f) * speed * Time.deltaTime, ForceMode.VelocityChange);
            //Apply turning to the rigidbody if able.
            if (turning != 0f)
            {
                if (topDown)
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hInput, 0f, vInput)), turning * Time.deltaTime);
                else
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hInput, vInput, 0f)), turning * Time.deltaTime);
            }
        }
    }

    void FindTarget()
    {
        if(!target)
            target = GameObject.FindGameObjectWithTag(targetTag); //Try to set target to the tag specified.
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player"); //Else, set target to the Player object.
    }
}
