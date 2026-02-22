using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemData;
    public void Pickup()
    {
        if (itemData == null)
        {
            Debug.LogError("No ItemData assigned on " + gameObject.name);
            return;
        }

        InventoryManager.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
