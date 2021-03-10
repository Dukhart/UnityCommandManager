using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCommand : ICommand
{
    GameObject cube; // input object
    Color color; // input colour
    Color previosColor; // orig colour
    public ClickCommand(GameObject cube, Color color)
    {
        this.cube = cube;
        this.color = color;
    }
    public void Execute()
    {
        // store previous color
        previosColor = cube.GetComponent<MeshRenderer>().material.color;
        // assign new color
        cube.GetComponent<MeshRenderer>().material.color = color;
    }

    public void Undue()
    {
        cube.GetComponent<MeshRenderer>().material.color = previosColor;
    }

}
