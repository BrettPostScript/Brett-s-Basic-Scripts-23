using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class JumpMover : MonoBehaviour
{
    //This code works when the object has a trigger collider underneath it to check for ground.
    public bool needsGround; //Mark as true if the object needs to be on the ground before it is able to jump.
    bool isGrounded; //Variable to check if the object is on the ground.
    public float force = 5f; //Jump force (All at once if needsGround is true.  Over time if needsGround is false).
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the rigidbody.
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            if (needsGround && isGrounded) //If needsGround is true and on the ground, apply force upwards.
                rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
        if(Input.GetButton("Jump"))
            if(!needsGround) //If it doesn't need the ground to jump, apply force over time.
                rb.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true; //If colliding with ground.
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false; //Once leaving ground.
    }
}
