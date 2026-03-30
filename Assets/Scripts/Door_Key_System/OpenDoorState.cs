using UnityEngine;


public class OpenDoorState : IDoorState
{
    public void EnterState(DoorController door)
    {
        Debug.Log("door is open");
    }

    public void Interact(DoorController door)
    {
        Debug.Log("Door is already open.");
    }
}