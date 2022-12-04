using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InitRandomVelocity : MonoBehaviour
{
    Vector3 vel; //Holder for start velocity.
    public float force = 1f; //Amount of force to work with.
    public bool topDown = true; //Mark as true to init force on the x,z axis.  Mark false to init force along the x,y axis.
    public bool simpleStart; //Mark as true to init the raw force value along one of 4 diagonal directions.  Mark as false to init a random force.

    void Start()
    {
        if (!simpleStart) //If not simple, init a random force at start.
        {
            if (topDown)
                vel = new Vector3(Random.Range(-force, force), 0f, Random.Range(-force, force));
            else
                vel = new Vector3(Random.Range(-force, force), Random.Range(-force, force), 0f);
        }
        else //If simple, init the basic force in 1 of 4 directions.
        {

            int horizontal = Random.Range(0, 2) * 2 - 1;
            int vertical = Random.Range(0, 2) * 2 - 1;

            if (topDown)
                vel = new Vector3((float)horizontal * force, 0f, (float)vertical * force);
            else
                vel = new Vector3((float)horizontal * force, (float)vertical * force, 0f);
        }
        GetComponent<Rigidbody>().AddForce(vel, ForceMode.VelocityChange); //Once the directions are decided, add force to the rigidbody.
    }
}
