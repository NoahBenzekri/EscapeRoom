using UnityEngine;

public class FuseboxController : MonoBehaviour
{
    private Animator animator;

    private bool playerInZone = false;
    private bool hasOpened = false;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F) && !hasOpened)
        {
            Debug.Log("F pressed, opening fusebox!");
            if (animator != null)
            {
                animator.SetBool("isOpen", true); 
            }
            hasOpened = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            Debug.Log("Player entered fusebox zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            Debug.Log("Player left fusebox zone");
        }
    }
}