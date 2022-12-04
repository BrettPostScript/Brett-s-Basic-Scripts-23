using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    public string button = "Fire1"; //Button use weapon.  Fire1 is the default.
    public float rate = 0.15f; //Rate of fire (1 is once each second, 0.5 is twice each second, etc.).
    float reloadTimer; //Timer to keep track of frequency.
    public GameObject spawn; //Spawnable projectile.
    public Transform origin; //Origin for the weapon to shoot from.
    public bool isMelee; //Mark as true if the projectile is a melee weapon, such as a sword (Melee weapons move with the attacking object).
    public bool autoFire; //Mark as true if the weapon is firing all the time.

    void Start()
    {
        if (!origin) //If no origin is specified, it becomes this object's position.
            origin = transform;
    }

    void Update()
    {
        reloadTimer -= Time.deltaTime; //Handle frequency timer.
        if (spawn && reloadTimer <= 0f) //If it is time tp spawn a new object.
        {
            if (button != "" && Input.GetButton(button) || autoFire) //If the button is pressed or the weapon is marked for autofire.
            {
                reloadTimer = rate; //Reset the timer.
                //Fire the weapon as either a melee or non-melee option.
                if (!isMelee)
                    GameObject.Instantiate(spawn, origin.position, origin.rotation);
                else
                    GameObject.Instantiate(spawn, origin.position, origin.rotation, origin);
            }
        }
    }
}
