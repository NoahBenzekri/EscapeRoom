using UnityEngine;

public class LockedDoorState : IDoorState
{
    public void EnterState(DoorController door)
    {
        Debug.Log("door is locked");
    }

    public void Interact(DoorController door)
    {
       if(door.requiredKey == null)
        {
             Debug.LogWarning("No key assigned.");
            return;
        }

        if(InventoryManager.Instance.HasItem(door.requiredKey))
        {
            Debug.Log("Used " + door.requiredKey.displayName + " to unlock the door.");

            if (door.consumeKeyOnUse)
            {
                InventoryManager.Instance.RemoveItem(door.requiredKey);
            }

            door.OpenDoorAnimations();
            door.SetState(new OpenDoorState());
        }
        else
        {
            Debug.Log("You need the " + door.requiredKey.displayName + " to unlock this door.");
        }
    }
}