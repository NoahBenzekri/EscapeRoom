using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerTests
{
    private InventoryManager manager;
    private GameObject testObject;

    [SetUp]
    public void Setup()
    {
        // Create the manager GameObject
        testObject = new GameObject("TestManager");
        manager = testObject.AddComponent<InventoryManager>();

        // Create fake UI slots so RefreshUI() doesn't crash
        manager.iconSlots = new Image[4];
        for (int i = 0; i < 4; i++)
        {
            GameObject slotGO = new GameObject($"Slot{i}");
            manager.iconSlots[i] = slotGO.AddComponent<Image>();
            manager.iconSlots[i].enabled = false;
        }
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.DestroyImmediate(testObject);
    }

    [Test]
    public void AddItem_ValidItem_AddsToInventory()
    {
        // Create a fake item
        ItemData testItem = ScriptableObject.CreateInstance<ItemData>();

        // Add it
        manager.AddItem(testItem);

        // Check if added
        Assert.AreEqual(1, manager.inventoryItems.Count);
    }
}