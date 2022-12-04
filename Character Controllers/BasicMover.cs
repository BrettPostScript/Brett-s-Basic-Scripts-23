using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class BasicMover : MonoBehaviour
{
    float hInput = 0f; //Horizontal input (x axis).
    float vInput = 0f; //Vertical input (y or z axis, depending on topDown).
    Rigidbody rb; //Gets the rigidbody.
    Animator anim; //Gets the animator controller.
    public float speed = 20f; //Movement speed applied to the rigidbody.
    public float turning; //Automatically turns the gameobject when moving (Mark as 0 to keep from turning).
    public bool topDown = true; //Mark as true to move object along the x,z axis.  Mark false for x,y axis movement.
    public bool lockVertical; //Mark true to ignore vertical inputs.
    public bool lockHorizontal; //Mark true to ignore horizontal inputs.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the rigidbody.
        anim = GetComponent<Animator>(); //Get the animator controller.
    }

    void Update()
    {
        //Get inputs for movement.
        if (!lockHorizontal)
            hInput = Input.GetAxis("Horizontal");
        if (!lockVertical)
            vInput = Input.GetAxis("Vertical");
        if (anim.runtimeAnimatorController)
        {
            if (vInput != 0f || hInput != 0f)
                anim.SetFloat("Speed", 1f);
            else
                anim.SetFloat("Speed", 0f);
        }
        //Add force towards the target position.
        if (topDown)
            rb.AddForce(new Vector3(hInput, 0f, vInput) * speed * Time.deltaTime, ForceMode.VelocityChange);
        else
            rb.AddForce(new Vector3(hInput, vInput, 0f) * speed * Time.deltaTime, ForceMode.VelocityChange);
        //Apply turning to the rigidbody if able.
        if (turning != 0f)
        {
            if (hInput != 0f || vInput != 0f)
            {
                if (topDown)
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hInput, 0f, vInput)), turning * Time.deltaTime);
                else
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hInput, vInput, 0f)), turning * Time.deltaTime);
            }
        }
    }
}
