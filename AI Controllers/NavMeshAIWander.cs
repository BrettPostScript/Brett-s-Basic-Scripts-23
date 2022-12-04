using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAIWander : MonoBehaviour
{
    public float patrolRange = 5f; //Generate a random point within range.
    public float frequencyInSeconds = 5f; //Frequency at which these points are generated.
    float patrolTimer; //Timer to keep track of frequency.
    NavMeshAgent agent; //Gets the NavMeshAgent on this object.

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Get the NavMeshAgent.
    }

    void Update()
    {
        patrolTimer -= Time.deltaTime; //Handle frequency timer.
        if (patrolTimer <= 0f) //if it is time to change to a new destination.
        {
            patrolTimer = frequencyInSeconds; //Reset the timer.
            Vector3 target = new Vector3(Random.Range(-patrolRange, patrolRange), transform.position.y, Random.Range(-patrolRange, patrolRange));
                agent.SetDestination(transform.position + target); //Set a new destination within range.
        }
    }
}
