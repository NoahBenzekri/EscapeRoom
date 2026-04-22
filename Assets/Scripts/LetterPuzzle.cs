using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterPuzzle : MonoBehaviour
{
    public string answer = "LIGHTNING";
    public TextMeshProUGUI answerDisplay;
    public ItemData keyItem;
    private string currentInput = "";

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            ClickButton();

        if (Input.GetKeyDown(KeyCode.Return))
            Submit();

    }

    void ClickButton()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            Button button = hit.collider.GetComponentInParent<Button>();
            if (button != null)
                button.onClick.Invoke();
        }
    }

    public void PressLetter(string letter)
    {
        currentInput += letter;
        UpdateText();
    }

    public void ClearInput()
    {
        currentInput = "";
        UpdateText();
    }

    public void  Submit()
    {
        if (currentInput.ToUpper() == answer.ToUpper())
        {
            answerDisplay.text = "Correct!";
            InventoryManager.Instance.AddItem(keyItem);
        }
        else
        {
            answerDisplay.text = "Wrong!";
            Invoke("ClearInput", 1.5f);
        }
    }

    void UpdateText()
    {
        answerDisplay.text = currentInput;
    }
}