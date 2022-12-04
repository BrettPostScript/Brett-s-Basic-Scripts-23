using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay : MonoBehaviour
{
    public string button = "Fire1"; //Button use weapon.  Fire1 is the default.
    public float range = 20f; //Range of the weapon in units.
    public Transform origin; //Origin for the weapon to shoot from.

    private void Start()
    {
        if (!origin) //If no origin is specified, it becomes this object's position.
            origin = transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(button)) //If the correct button is pressed.
        {
            if(Physics.Raycast(origin.position, transform.forward, out RaycastHit hit, range)) //And there is an object within the line of effect.
            {
                hit.collider.gameObject.SendMessage("Kill", SendMessageOptions.DontRequireReceiver); //Try to kill the object, outright.
            }
        }
    }
}
