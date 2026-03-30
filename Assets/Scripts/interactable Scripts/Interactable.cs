using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public UnityEvent onInteract;
    public static bool Iszoomed;

    public virtual void Start()
    {
       outline = GetComponent<Outline>();
       disableOutline();
    }

    public virtual void Interact()
    {
        onInteract?.Invoke();
    }

    public virtual void Take()
    {
        Debug.Log("Nothing here Pal");
    }
    public void enableOutline()
    {
        
    }

    public void disableOutline()
    {
    }
      public static void EnterZoomMode()
    {
        Iszoomed = true;
    }

    public static void ExitZoomMode()
    {
        Iszoomed = false;
    }
}
