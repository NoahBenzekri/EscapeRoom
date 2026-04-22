using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenTeleporter : MonoBehaviour
{
    private string winSceneName = "MainMenu";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Player entered win screen teleporter zone");
            UnityEngine.SceneManagement.SceneManager.LoadScene(winSceneName);
            Destroy(InventoryManager.Instance.gameObject);
        }
    }
    
}
