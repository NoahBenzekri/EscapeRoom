using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
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
    }

    public void AddItem(ItemData item)
    {
        inventoryItems.Add(item);
        Debug.Log("Added to inventory: " + item);
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
