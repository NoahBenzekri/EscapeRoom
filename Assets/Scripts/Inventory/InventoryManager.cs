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

        RefreshUI();
    }
    void Update()
    {
        HandleInput();

    }

    public void AddItem(ItemData item)
    {
        inventoryItems.Add(item);
        Debug.Log("Added to inventory: " + item);

        for (int i = 0; i < iconSlots.Length; i++)
        {
            if (!iconSlots[i].enabled)
            {
                iconSlots[i].sprite = item.icon;
                iconSlots[i].enabled = true;
                iconSlots[i].gameObject.SetActive(true);
                return;
            }
        }
    }

    public void SelectSlot(int index)
    {
        if (index < 0 || index >= inventoryItems.Count)
        {
            selectedSlot = -1;
            return;
        }
        selectedSlot = index;
        ItemData item = inventoryItems[selectedSlot];
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

    public void RemoveSelectedItem()
    {
        if (selectedSlot == -1 || selectedSlot >= inventoryItems.Count) return;

        inventoryItems.RemoveAt(selectedSlot);
        ItemHoldManager.Instance.HideItem();

        if (selectedSlot >= inventoryItems.Count)
        {
            selectedSlot = -1;
        }
        RefreshUI();
    }
    public void RemoveItem(ItemData item)
    {
        int index = inventoryItems.IndexOf(item);
        if (index == -1) return;

        inventoryItems.RemoveAt(index);
        if (selectedSlot == index)
        {
            selectedSlot = -1;
        }
        else if (selectedSlot > index)
        {
            selectedSlot--;
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < iconSlots.Length; i++)
        {
            iconSlots[i].enabled = false;
            iconSlots[i].sprite = null;
            iconSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < inventoryItems.Count && i < iconSlots.Length; i++)
        {
            iconSlots[i].sprite = inventoryItems[i].icon;
            iconSlots[i].enabled = true;
            iconSlots[i].gameObject.SetActive(true);
        }
    }
    public ItemData GetSelectedItem()
    {
        if (selectedSlot == -1 || selectedSlot >= inventoryItems.Count)
        {
            return null;
        }
        else
        {
            return inventoryItems[selectedSlot];
        }
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSelectedItem();
        }
    }


}
