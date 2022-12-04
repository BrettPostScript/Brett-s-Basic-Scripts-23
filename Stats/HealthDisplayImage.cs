using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BasicHealth))]
public class HealthDisplayImage : MonoBehaviour
{
    //This script makes use of the Image.fillAmount property that ranges from 0 to 1, which works for various health bars.

    public Image displayImage; //Image to display health percentage.
    BasicHealth health; //Holder for BasicHealth reference.

    void Start()
    {
        health = GetComponent<BasicHealth>(); //Get BasicHealth.
    }

    void Update()
    {
        displayImage.fillAmount = health.GetHealthPercent(); //Cut away at image as a percentage of maximum health.
    }
}
