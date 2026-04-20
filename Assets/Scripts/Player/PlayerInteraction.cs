using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    Interactable currentInteractable;
    public TextMeshProUGUI interactionText;

    void Update()
    {

        if (Interactable.Iszoomed)
        {
            interactionText.gameObject.SetActive(false);
            return;
        }
        CheckForInteractable();

      if (currentInteractable != null)
        {
            interactionText.gameObject.SetActive(true);

            ItemPickUp item = currentInteractable.GetComponent<ItemPickUp>();
            DoorInteractable door = currentInteractable.GetComponent<DoorInteractable>();

            if (item != null)
            {
                ItemData data = item.itemData;

                if (data.itemType == Itemtype.Note)
                {
                    interactionText.text = "Press E to read\nPress F to pick up";
                }
                else if (data.itemType == Itemtype.Food)
                {
                    interactionText.text = "Press E to eat\nPress F to pick up";
                }
                else if (data.itemType == Itemtype.Battery)
                {
                    interactionText.text = "Press E to use\nPress F to pick up";
                }
                else if (data.itemType == Itemtype.Flashlight || data.itemType == Itemtype.Key)
                {
                    interactionText.text = "Press F to pick up";
                }
                else if (data.itemType == Itemtype.PuzzlePiece)
                {
                    interactionText.text = "Press E to examine";
                }
                else
                {
                    interactionText.text = "Press E to interact";
                }
            }
            else if (door != null)
            {
                interactionText.text = "Press E to open";
            }
            else if(currentInteractable.GetComponent<PanellButton>() != null)
            {
                interactionText.text = "Click on button to stop";
            }
            else
            {
                interactionText.text = "Press E to interact";
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
            if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
            {
                currentInteractable.Interact();

            }
            if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
            {
                ItemPickUp pickUp = currentInteractable.GetComponent<ItemPickUp>();
                if (pickUp != null)
                {
                    interactionText.gameObject.SetActive(false);
                    currentInteractable = null;
                    pickUp.Pickup();

                }
            }

            if (Input.GetMouseButtonDown(0))
        {
                  if (EventSystem.current.IsPointerOverGameObject()) return;

            ItemData selected = InventoryManager.Instance.GetSelectedItem();
            if(selected?.itemType == Itemtype.Note)
            {
             NotePopUp.Instance.PopUpToFace();
            }
        
        }

    }
        void CheckForInteractable()
        {
            if (Camera.main == null)
            {
                DisableCurrentInteractable();
                return;
            }

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.green);

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Interactable newInteractable = hit.collider.GetComponentInParent<Interactable>();

                if (newInteractable != null && newInteractable.enabled)
                {
                    if (currentInteractable != newInteractable)
                    {
                        DisableCurrentInteractable();
                        currentInteractable = newInteractable;
                        currentInteractable.enableOutline();
                    }

                    return;
                }
            }

            DisableCurrentInteractable();
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

