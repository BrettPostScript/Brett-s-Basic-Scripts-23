using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    public string targetTag = "Player"; //Target to look for, should be "Player" by default.
    public float range = 10f; //Range of weapon.
    public float rate = 0.15f; //Rate of fire (1 is once each second, 0.5 is twice each second, etc.).
    float reloadTimer; //Timer to keep track of frequency.
    public GameObject spawn; //Spawnable projectile.
    public Transform origin; //Origin for the weapon to shoot from.
    public bool isMelee; //Mark as true if the projectile is a melee weapon, such as a sword (Melee weapons move with the attacking object).

    private void Start()
    {
        if (!origin) //If no origin is specified, it becomes this object's position.
            origin = transform;
    }

    void Update()
    {
        reloadTimer -= Time.deltaTime; //Handle frequency timer.
        if (spawn && reloadTimer <= 0f) //If it is time tp spawn a new object.
        {
            if (Physics.Raycast(origin.position, transform.forward, out RaycastHit hit, range))
            {
                if (hit.collider.gameObject.tag == targetTag) //If the target is within sight and range.
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
}
