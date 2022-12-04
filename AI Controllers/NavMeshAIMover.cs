using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAIMover : MonoBehaviour
{
    public string targetTag = "Player"; //Target to look for, should be "Player" by default.
    public float lookRange = 10f; //Range of AI senses.
    public float fovAngle = 90f; //Angle of field of view.
    NavMeshAgent agent; //Gets the NavMeshAgent on this object.
    GameObject target; //Gets the target gameObject.
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Get NavMeshAgent.
        target = GameObject.FindGameObjectWithTag(targetTag); //Get target object.
    }

    void Update()
    {
        if (target) //If target != null
            if (Vector3.Distance(transform.position, target.transform.position) < lookRange && Mathf.Abs(Vector3.Angle(transform.forward, (target.transform.position - transform.position).normalized)) < (fovAngle / 2f)) //If within range and FoV.
                if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out RaycastHit hit) && hit.collider.tag == targetTag)
                    agent.SetDestination(hit.point); //If the target exists within the field of view and is not obstructed, set desination.
    }
}
