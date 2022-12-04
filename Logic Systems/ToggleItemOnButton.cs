using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItemOnButton : MonoBehaviour
{
    //This script toggles a game object (usually a menu) and can pause the game while doing so.

    public string button = "Cancel"; //Button to toggle item visibility.  Default is Cancel.
    public GameObject target; //Target gameObject to toggle.
    public bool pause = true; //Mark as true if the game pauses when object is toggled on.

    void Update()
    {
        if (target) //If target != null
            if (Input.GetButtonDown(button)) //If the button is pressed.
            {
                if (!target.activeInHierarchy) //If the target gameObject is not active.
                {
                    target.SetActive(true); //Make the target gameObject active.
                    if (pause)
                        Time.timeScale = 0f; //Pause the game if pause is true.
                }
                else //Else, if the target gameObject is active.
                {
                    target.SetActive(false); //Make the target gameObject not active.
                    if (pause)
                        Time.timeScale = 1f; //Unpause the game if pause is true.
                }
            }
    }
}
