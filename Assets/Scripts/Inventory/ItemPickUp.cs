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
