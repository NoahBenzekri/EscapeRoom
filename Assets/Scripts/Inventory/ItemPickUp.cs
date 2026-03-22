using TMPro;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemData;
    public bool dontDestroy = false;
    public void Pickup()
    {
        if (itemData == null)
        {
            Debug.LogError("No ItemData assigned on " + gameObject.name);
            return;
        }

        InventoryManager.Instance.AddItem(itemData);
        if (dontDestroy)
        {
            gameObject.SetActive(false);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
