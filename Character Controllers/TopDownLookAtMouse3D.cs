using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownLookAtMouse3D : MonoBehaviour
{
    void Update() //This method works with a perspective camera.
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get mouse position in the world.
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z)); //look at approximate mouse position.
        }
    }
}
