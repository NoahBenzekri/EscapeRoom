using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Image[] iconSlots = new Image[4];

    private int selectedSlot = -1;
    public List<ItemData> inventoryItems = new List<ItemData>();

     void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Image icon in iconSlots)
        {
            icon.enabled = false;
            // make sure icon is false on load
        }
    }

    public void AddItem(ItemData item)
    {
        inventoryItems.Add(item);
        Debug.Log("Added to inventory: " + item);

        for(int i = 0; i < iconSlots.Length; i++)
        {
            if (!iconSlots[i].sprite!= null)
            {
                iconSlots[i].gameObject.SetActive(true);
            }
            if (!iconSlots[i].enabled)
            {
                
                iconSlots[i].sprite = item.icon;
                iconSlots[i].enabled = true;
                return;
            }
        }
    }

    public void SelectSlot(int index)
    {
        selectedSlot = index;
        Debug.Log("Selected:" + inventoryItems[selectedSlot].displayName);
        ItemHoldManager.Instance.ShowItem(inventoryItems[selectedSlot]);
    }
    public void UseSelectedItem()
    {
        if (selectedSlot == -1 || selectedSlot >= inventoryItems.Count) return;

        ItemData item = inventoryItems[selectedSlot];

        switch (item.itemType)
        {
            case Itemtype.Key:
                Debug.Log("Used Key");
                break;

            case Itemtype.Flashlight:
                Debug.Log("Toggled Flashlight");
                break;

            case Itemtype.Battery:
                Debug.Log("Used Battery");
                break;
        }
    
    }
    public bool HasItem(ItemData item)
    {
        return inventoryItems.Contains(item);
    }   

    public void RemoveItem(ItemData item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log("Removed from inventory: " + item);
        }
    }

    public ItemData GetSelectedItem()
    {
        if(selectedSlot == -1 || selectedSlot >= inventoryItems.Count)
        {
            return null;
        }
        else
        {
            return inventoryItems[selectedSlot];
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);

        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);

        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
             SelectSlot(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        } 
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSelectedItem();
        }
      
    
    }
}
