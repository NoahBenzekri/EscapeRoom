using UnityEngine;

public class DoorInteractable : Interactable
{
   public DoorController doorController;

    public override void Interact()
    {
        if(doorController != null)
        {
            doorController.Interact();
        }
    }
}