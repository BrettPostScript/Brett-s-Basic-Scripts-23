using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnCollide : MonoBehaviour
{
    public string restrictToTag = "Player"; //Specify a tag to limit to only objects with that tag (eg. Player).

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == restrictToTag || restrictToTag == "") //If collider object matches tag or no tag is given.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene.
    }
}
