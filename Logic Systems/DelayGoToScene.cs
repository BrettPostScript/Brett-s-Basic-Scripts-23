using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayGoToScene : MonoBehaviour
{
    public float seconds = 2f; //Delay in seconds.
    public string sceneName; //String variable for the scene name in the build.

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0f) //After 'x' seconds.
            SceneManager.LoadScene(sceneName); //Load the specified scene by name.
    }
}
