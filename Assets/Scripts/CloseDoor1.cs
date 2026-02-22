using UnityEngine;

public class CloseDoor1 : MonoBehaviour
{
    public Animation doorAnimation;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimation.Play();
            GetComponent<Collider>().enabled = false; // Disable the collider to prevent multiple triggers
        }
    }

}
