using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LerpToPlayer : MonoBehaviour
{
    //Lerp stands for linear interpolation and is a nice tool to safely guide an object toward a destination.

    GameObject player; //Holds the player object.
    Rigidbody rb; //Gets the rigidbody.
    public float range = 3f; //Range at which the lerping takes effect.
    public float speed = 10f; //Speed at which the lerping takes effect.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Get the player object.
        rb = GetComponent<Rigidbody>(); //Get the rigidbody.
    }

    void Update()
    {
        if (player) //If a player object exists.
        {
            if (Vector3.Distance(transform.position, player.transform.position) < range) //If the player is within range of the object.
            {
                rb.AddForce((player.transform.position - transform.position).normalized * (speed * 15f) * Time.deltaTime, ForceMode.VelocityChange); //Add force to help in tracking.  The force is multiplied by 15 to make things easier.
                transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime); //Lerp towards the player.
            }
        }
    }
}
