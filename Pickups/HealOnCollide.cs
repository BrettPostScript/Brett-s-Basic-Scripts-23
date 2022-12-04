using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnCollide : MonoBehaviour
{
    public float heal = 0.25f; //The amount of health this object heals.
    public bool selfDestruct = true; //Mark as true if this object destroys itself upon collision.
    public string restrictToTag = "Player"; //Specify a tag to limit to only objects with that tag (eg. Player).

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
        {
            collision.gameObject.SendMessage("Heal", heal, SendMessageOptions.DontRequireReceiver); //Try to heal the collider object.
            if (selfDestruct)
                Destroy(gameObject); //Destroy this object.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
        {
            other.gameObject.SendMessage("Heal", heal, SendMessageOptions.DontRequireReceiver); //Try to heal the collider object.
            if (selfDestruct)
                Destroy(gameObject); //Destroy this object.
        }
    }
}
