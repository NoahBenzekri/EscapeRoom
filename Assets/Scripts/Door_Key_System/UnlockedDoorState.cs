using UnityEngine;


public class UnlockedDoorState : IDoorState
{
    public void EnterState(DoorController door)
    {
        Debug.Log("door is unlocked");
    }

    public void Interact(DoorController door)
    {
        door.OpenDoorAnimations();
        door.SetState(new OpenDoorState());
    }
}