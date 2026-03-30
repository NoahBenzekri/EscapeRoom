using UnityEngine;

public class DoorController : MonoBehaviour
{
   public bool StartLocked = true;
   public ItemData requiredKey;
   public bool consumeKeyOnUse = true;


   public Animator animator;
   public string OpenTrigger = "Open";


    private IDoorState currentState;


    void Start()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (StartLocked)
        {
            SetState(new LockedDoorState());
        }
        else
        {
            SetState(new UnlockedDoorState());
        }
    }


    public void Interact()
    {
        currentState?.Interact(this);
    }



    public void SetState(IDoorState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void OpenDoorAnimations()
    {
       if(animator != null)
        {
            animator.SetTrigger(OpenTrigger);
        }
    }
}