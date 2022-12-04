using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AILaser : MonoBehaviour
{
    public string targetTag = "Player"; //Target to look for, should be "Player" by default.
    public float range = 10f; //Range of weapon.
    public float dps = 0.25f; //Damage per second of the weapon.
    LineRenderer lr; //Holder for the line renderer (laser).
    public Transform origin; //Origin for the weapon to shoot from.

    private void Start()
    {
        if (!origin) //If no origin is specified, it becomes this object's position.
            origin = transform;
        lr = GetComponent<LineRenderer>(); //Get line renderer.
    }

    void Update()
    {
        //Reset the line renderer's position at the beginning of the update.
        lr.SetPosition(0, origin.position);
        lr.SetPosition(1, origin.position);

        if (Physics.Raycast(origin.position, transform.forward, out RaycastHit hit, range))
        {
            if (hit.collider.gameObject.tag == targetTag) //If the target is within sight and range.
            {
                lr.SetPosition(1, hit.point); //Set the end of the line to the point of contact.
                hit.collider.gameObject.SendMessage("Damage", dps * Time.deltaTime, SendMessageOptions.DontRequireReceiver); //Try to cause damage over time.
            }
        }
    }
}
