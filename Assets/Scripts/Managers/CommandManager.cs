using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    private static CommandManager instance;
    public static CommandManager Instance
    {
        get
        {
            if (instance == null) Debug.LogError("Command Manager is null");
            return instance;
        }
    }
    List<ICommand> commandBuffer = new List<ICommand>();

    private void Awake()
    {
        instance = this;
    }
    // adds command to buffer
    public void AddCommandToBuffer (ICommand command)
    {
        commandBuffer.Add(command);
    }
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }
    // Done changing commands
    public void DoneButton()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
    public void ResetButton()
    {
        DoneButton();
        ClearCommandBuffer();
    }
    // play all commands
    IEnumerator PlayRoutine()
    {
        Debug.Log("START Command Manager Play");
        foreach (ICommand command in commandBuffer) {
            command.Execute();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("END Command Manager Play");
    }
    // rewind all comands
    IEnumerator RewindRoutine()
    {
        Debug.Log("START Command Manager Rewind");
        foreach (ICommand command in Enumerable.Reverse(commandBuffer))
        {
            command.Undue();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("END Command Manager Rewind");
    }
    
    // Clears command buffer
    void ClearCommandBuffer ()
    {
        commandBuffer.Clear();
    }
}
