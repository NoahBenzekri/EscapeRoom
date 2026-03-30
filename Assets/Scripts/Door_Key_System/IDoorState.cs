using UnityEngine;

public interface IDoorState
{
    void EnterState(DoorController door);
    void Interact(DoorController door);
}