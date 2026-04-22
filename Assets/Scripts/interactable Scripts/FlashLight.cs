using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject on;
    public GameObject off;

    private bool isON = false;

    void Start()
    {
        on.SetActive(false);
        off.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isON = !isON;

            on.SetActive(isON);
            off.SetActive(!isON);
        }
    }
}