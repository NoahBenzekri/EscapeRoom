using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour
{
    public GameObject on;
    public GameObject off;

    private bool isON;

    void Start()
    {
        on.SetActive(false);
        off.SetActive(true);
        isON=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& InventoryManager.Instance.GetSelectedItem()?.itemType == Itemtype.Flashlight)
        {
            if (isON)
            {   

                  on.SetActive(false);
                  off.SetActive(true);        

            }

            if (!isON)
            {
                on.SetActive(true);
                off.SetActive(false);        

            }

            isON=!isON;
        }
    }
}
