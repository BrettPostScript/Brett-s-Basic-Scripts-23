using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMover : MonoBehaviour
{
    public string button = "Fire1"; //Button to set destination.  Fire1 is the default.
    NavMeshAgent agent; //Gets the NavMeshAgent on this object.

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Get NavMeshAgent.
    }

    void Update()
    {
        if (Input.GetButton(button)) //If the button is pressed.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get mouse position in the world.
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 1f, NavMesh.AllAreas); //Check if valid NavMesh position.
                if(navHit.hit)
                    agent.SetDestination(hit.point); //Set new destination.
            }
        }
    }
}
