using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // left click
        if (Input.GetMouseButtonDown(0))
        {
            // get ray
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            // cast ray / check for hit
            if (Physics.Raycast(rayOrigin,out hitInfo))
            {
                // check we hit a cube
                if (hitInfo.collider.CompareTag("Cube"))
                {
                    // execute command
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject, new Color().Random());
                    CommandManager.Instance.AddCommandToBuffer(click);
                    click.Execute();
                }
            }
        }
    }
}
