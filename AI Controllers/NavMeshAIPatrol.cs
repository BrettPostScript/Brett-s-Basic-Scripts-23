using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAIPatrol : MonoBehaviour
{
    public Transform[] points; //Collection of positions to patrol.
    public float frequencyInSeconds = 5f; //Frequency at which these points are alternated.
    public bool sequential; //Mark as true to cylce through points.  Mark as false to randomly select points.
    int sequencePlace; //This is used as a place holder if sequential is true.
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
            if (points.Length > 0)
            {
                Vector3 target;
                if (sequential) //Cycle through points if sequential.
                {
                    sequencePlace++;
                    if (sequencePlace > points.Length - 1) //If reached the end, return to the beginning.
                        sequencePlace = 0;
                    target = points[sequencePlace].position;
                }
                else //Else, select a random point in the list.
                {
                    target = points[Random.Range(0, points.Length)].position;
                    
                }
                agent.SetDestination(target);
            }
        }
    }
}
