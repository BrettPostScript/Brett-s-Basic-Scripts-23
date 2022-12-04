using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfKillOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.SendMessage("Drop", SendMessageOptions.DontRequireReceiver); //Try to drop items.
        Destroy(gameObject); //Destroy this object.
    }
}
