using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTextureParallax : MonoBehaviour
{
    //This script handles parallax textures via scrolling the offset on a material.

    public Vector2 speed; //Speed of the scroll on each axis.
    MeshRenderer mesh; //Holds the mesh.
    Material mat; //Holds the material.

    void Start()
    {
        mesh = GetComponent<MeshRenderer>(); //Get the mesh.
        mat = mesh.material; //Get the material.
    }

    void Update()
    {
        mat.mainTextureOffset += speed * Time.deltaTime; //Scroll material texture across mesh.
    }
}
