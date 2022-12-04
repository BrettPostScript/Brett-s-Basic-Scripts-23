using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ChangeVelocityOnCollide : MonoBehaviour
{
    Rigidbody rb; //Gets the rigidbody.
    float maxVel = 30f; //Maximum velocity cap.  Make public to edit, but this number should be sufficient.
    public float multiplier = 1.1f;  //Set to 1 for no change in velocity.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the rigidbody.
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity *= multiplier; //Multiply velocity on collide.
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel); //Clamp outrageous velocity.
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.velocity *= multiplier; //Multiply velocity on collide.
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel); //Clamp outrageous velocity.
    }
}
