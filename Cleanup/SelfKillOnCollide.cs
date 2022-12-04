using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SelfKillOnCollide : MonoBehaviour
{
    public string restrictToTag = ""; //Specify a tag to limit to only objects with that tag (eg. Player).

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
        {
            gameObject.SendMessage("Drop", SendMessageOptions.DontRequireReceiver); //Try to drop items.
            Destroy(gameObject); //Destroy this object.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
        {
            gameObject.SendMessage("Drop", SendMessageOptions.DontRequireReceiver); //Try to drop items.
            Destroy(gameObject); //Destroy this object.
        }
    }
}
