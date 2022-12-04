using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHealth : MonoBehaviour
{
    public float health = 1f; //Starting health amount.
    float maxHealth; //Max health (automatically sets to current health at start).

    private void Start()
    {
        maxHealth = health; //Set max health to starting health.
    }

    //Decrease current health by num.  If it reaches 0, kill the object.
    public void Damage(float num)
    {
        health -= num;
        if (health <= 0f)
            Kill();
    }

    //Increase current health by num.  Cap it at max health.
    public void Heal(float num)
    {
        health += num;
        if (health > maxHealth)
            health = maxHealth;
    }

    //Special function that tries to drop loot and then destroys this game object.
    public void Kill()
    {
        gameObject.SendMessage("Drop", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    //Returns a number between 0 and 1 as a percentage of health.
    public float GetHealthPercent()
    {
        return health / maxHealth;
    }
}
