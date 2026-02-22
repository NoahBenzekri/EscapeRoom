using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    Interactable currentInteractable;

    public TextMeshProUGUI interactionText;

    void Update()
    {
        CheckForInteractable();

        if(currentInteractable != null)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Press E to View \n Press F to Take";

        } else
        {
            interactionText.gameObject.SetActive(false);
           
        }
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
                   currentInteractable.Interact();
                     Interactable.EnterZoomMode();

        }
        

        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            ItemPickUp pickUp = currentInteractable.GetComponent<ItemPickUp>();
            if (pickUp != null)
            {
              pickUp.Pickup();
          
            }    
        }         

        if(Interactable.Iszoomed )
        {
            interactionText.gameObject.SetActive(false);
            return;
        }
    }
    void CheckForInteractable()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            Interactable newInteractable = hit.collider.GetComponentInParent<Interactable>();

            if (newInteractable != null && newInteractable.enabled)
            {
                if (currentInteractable != null && newInteractable != currentInteractable)
                    currentInteractable.disableOutline();

                SetNewCurrentInteractable(newInteractable);
               
                return;
            }
        }

        DisableCurrentInteractable();
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.enableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable.disableOutline();
            currentInteractable = null;
        }
    }

   
}
