using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BasicHealth))]
public class HealthDisplay : MonoBehaviour
{
    public string healthType = "HP: "; //Health label prefix.
    public TMP_Text healthText; //Health text object.
    BasicHealth health; //Holder for the BasicHealth reference.

    void Start()
    {
        health = GetComponent<BasicHealth>(); //Get BasicHealth.
    }

    void Update()
    {
        if (healthText) //If text object specified.
            healthText.text = healthType + (int)(100f * health.GetHealthPercent()) + "%"; //Display a percentage of health.
    }
}
