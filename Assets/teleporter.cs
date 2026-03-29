using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestination; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
          
            other.transform.position = teleportDestination.position;
            other.transform.rotation = teleportDestination.rotation;
        }
    }
}
