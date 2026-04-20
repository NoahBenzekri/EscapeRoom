using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public Light spotlight;

    private bool isON;

    void Start()
    {
        on.SetActive(false);
        off.SetActive(true);
        isON = false;
    }

    void Update()
    {
        if (InventoryManager.Instance.GetSelectedItem()?.itemType != Itemtype.Flashlight) return;

        if (Input.GetMouseButtonDown(0))
        {
            isON = !isON;
            on.SetActive(isON);
            off.SetActive(!isON);
            spotlight.color = Color.white;
        }

        if (isON)
        {
            if (Input.GetMouseButton(1)) // hold right click → purple
                spotlight.color = new Color(0.5f, 0f, 1f);
            else
                spotlight.color = Color.white; // release → back to white
        }
    }
}