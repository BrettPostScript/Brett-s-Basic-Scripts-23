using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public string button = "Fire1"; //Button use weapon.  Fire1 is the default.
    public float range = 20f; //Range of the weapon in units.
    public float dps = 1f; //Damage per second of the weapon.
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
        
        if (Input.GetButton(button)) //If the correct button is pressed.
        {
            if(Physics.Raycast(origin.position, transform.forward, out RaycastHit hit, range)) //And there is an object within the line of effect.
            {
                lr.SetPosition(1, hit.point); //Set the end of the line to the point of contact.
                hit.collider.gameObject.SendMessage("Damage", dps * Time.deltaTime, SendMessageOptions.DontRequireReceiver); //Try to cause damage over time.
            }
        }        
    }
}
