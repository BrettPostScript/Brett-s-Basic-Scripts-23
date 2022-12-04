using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownLookAtMouse2D : MonoBehaviour
{
    void Update() //This method works with an orthographic camera.
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get mouse position in the world.
        worldPos.y = transform.position.y;
        transform.LookAt(worldPos); //look at approximate mouse position.
    }
}
