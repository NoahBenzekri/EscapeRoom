using UnityEngine;
using UnityEngine.AI;

public class ItemHoldManager : MonoBehaviour
{

    public static ItemHoldManager Instance;
    public Transform holdPoint;

    private GameObject currentItem;

    void Start()
    {
        Instance = this;
    }

    public void ShowItem(ItemData item)
    {
        if(currentItem != null)
        {
            Destroy(currentItem);
        }

        if(item.heldPrefab == null)
        {
            return;
        }

        currentItem = Instantiate(item.heldPrefab,holdPoint);
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localRotation = Quaternion.Euler(90,0,0);
    }
    public void HideItem()
    {
        if(currentItem != null)
        {
            Destroy(currentItem);
        }
    }
    void Update()
    {
        

    }
}
