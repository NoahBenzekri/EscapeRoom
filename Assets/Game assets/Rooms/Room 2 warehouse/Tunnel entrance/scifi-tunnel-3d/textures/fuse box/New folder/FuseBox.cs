using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public Animator animator; 
    public KeyCode interactKey = KeyCode.E; 
    private bool isOpened = false; 

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isOpened)
        {
            animator.Play("DoorOpen"); 
            isOpened = true;

           
            StartCoroutine(FreezeAnimatorAtEnd());
        }
    }

    System.Collections.IEnumerator FreezeAnimatorAtEnd()
    {
       
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.enabled = false; 
    }
}