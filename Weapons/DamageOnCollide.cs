using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageOnCollide : MonoBehaviour
{
    public float damage = 1f; //Damage to inflict on collision.
    public bool selfDestruct = true; //Mark as true if the object should destroy itself on collision.

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver); //Try to damage collider object.
        if (selfDestruct)
        {
            gameObject.SendMessage("Drop", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject); //Destroy this object.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver); //Try to damage collider object.
        if (selfDestruct)
        {
            gameObject.SendMessage("Drop", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject); //Destroy this object.
        }
    }
}
