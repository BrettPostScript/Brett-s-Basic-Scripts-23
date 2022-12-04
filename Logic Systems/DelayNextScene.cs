using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayNextScene : MonoBehaviour
{
    public float seconds = 2f; //Delay in seconds.
    
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0f) //After 'x' seconds.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the next scene in the build.
    }
}
