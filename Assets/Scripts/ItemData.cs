using UnityEngine;

 public enum Itemtype
    {
        Key,
        Flashlight,
        PuzzlePiece,
        Battery,
        Note,
        food,
        
    }
[CreateAssetMenu(fileName = "New item", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public Itemtype itemType;
    public string displayName;
    public Sprite icon;
    public GameObject heldPrefab;
}
