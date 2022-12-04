using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DpsOnCollide : MonoBehaviour
{
    public float damage = 1f; //Damage to inflict on collision.
    public string restrictToTag = "Player"; //Specify a tag to limit to only objects with that tag (eg. Player).

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
        {
            other.gameObject.SendMessage("Damage", damage * Time.deltaTime, SendMessageOptions.DontRequireReceiver); //Try to damage collider object.
        }
    }
}
