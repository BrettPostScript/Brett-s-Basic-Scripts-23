using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicObjectives : MonoBehaviour
{
    public string playerTag = "Player"; //Default player tag.
    GameObject player; //Holder for the player object.
    
    public bool killAll; //Mark as true if required to kill all objects of a certain tag.
    public string killTag = "Enemy";
    public int killsRemaining;

    public bool protectAll; //Mark as true if required to protect objects of a certain tag.
    public string protectTag = "Ally";
    public int alliesRemaining;

    public bool loseIfTimeOut; //Mark as true if required to complete within a certain time.
    public bool winIfTimeOut; //Mark as true if required to survive until a certain time.
    public float seconds;

    public bool winIfReachPoint; //Mark as true if required to reach a certan position in the scene.
    public Transform point;

    public string winScene = "Succcess"; //Scene name on objective complete.
    public string loseScene = "GameOver"; //Scene name on objective failed.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag); //Get player object.
    }

    void Update()
    {
        if (killAll)
        {
            killsRemaining = GameObject.FindGameObjectsWithTag(killTag).Length; //Get targets remaining.
            if (killsRemaining <= 0) //If no more targets, go to win scene.
                SceneManager.LoadScene(winScene);
        }
        if (protectAll)
        {
            alliesRemaining = GameObject.FindGameObjectsWithTag(protectTag).Length; //Get targets remaining.
            if (alliesRemaining <= 0) //If no more targets, go to lose scene.
                SceneManager.LoadScene(loseScene);
        }
        if (loseIfTimeOut)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0) //If timer reaches 0, go to lose scene.
                SceneManager.LoadScene(loseScene);
        }
        else if (winIfTimeOut)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0) //If timer reaches 0, go to win scene.
                SceneManager.LoadScene(winScene);
        }
        if (winIfReachPoint)
        {
            if (point && player)
                if (Vector3.Distance(player.transform.position, point.position) < 1f) //If player reached point, go to win scene.
                    SceneManager.LoadScene(winScene);
        }
        if (!player) //If the player ever dies.
        {
            SceneManager.LoadScene(loseScene); //Go to lose scene.
        }
    }
}
