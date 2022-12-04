using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehavior : MonoBehaviour
{
    public float force = 15f; //Start velocity.
    public float spread = 0.1f; //Amount of directional variance (Keep very low.  0 means it fired completely straight).
    Rigidbody rb; //Gets the rigidbody.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the rigidbody.
        //Add force along forward vector.
        rb.AddForce((transform.forward + new Vector3(Random.Range(-spread,spread), Random.Range(-spread, spread), Random.Range(-spread, spread))) * force, ForceMode.VelocityChange);
    }
}
