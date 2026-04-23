using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination;
    [SerializeField] private float cooldownTime = 0.5f;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer(other));
        }
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        canTeleport = false;

        CharacterController controller = player.GetComponent<CharacterController>();
        Rigidbody rb = player.GetComponent<Rigidbody>();

        
        if (controller != null)
            controller.enabled = false;

       
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

       
        player.transform.SetPositionAndRotation(
            teleportDestination.position,
            teleportDestination.rotation
        );

        yield return null;

        if (controller != null)
            controller.enabled = true;

        yield return new WaitForSeconds(cooldownTime);

        canTeleport = true;
    }
}