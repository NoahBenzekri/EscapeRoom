using UnityEngine;
using UnityEngine.UI; 

public class FuseBoxInteract : MonoBehaviour
{
    public Animator animator;
    public KeyCode interactKey = KeyCode.E;
    public GameObject interactUI; 
    public float interactDistance = 3f; 
    private bool isOpened = false;

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject == gameObject) 
            {
                interactUI.SetActive(!isOpened); 

                if (Input.GetKeyDown(interactKey) && !isOpened)
                {
                    animator.Play("DoorOpen");
                    isOpened = true;
                    interactUI.SetActive(false); 
                    StartCoroutine(FreezeAnimatorAtEnd());
                }
            }
            else
            {
                interactUI.SetActive(false);
            }
        }
        else
        {
            interactUI.SetActive(false);
        }
    }

    System.Collections.IEnumerator FreezeAnimatorAtEnd()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.enabled = false;
    }
}
