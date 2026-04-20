using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LetterPuzzle : MonoBehaviour
{
    public string answer = "LIGHTNING";
    public TextMeshProUGUI answerDisplay;
    public ItemData keyItem;
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    private string currentInput = "";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(eventSystem);
            pointerData.position = new Vector2(Screen.width / 2, Screen.height / 2);

            var results = new System.Collections.Generic.List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            if (results.Count > 0)
            {
                GameObject hit = results[0].gameObject;

                Button button = hit.GetComponent<Button>();
                if (button == null)
                    button = hit.GetComponentInParent<Button>();

                if (button != null)
                    button.onClick.Invoke();
            }
        }
    }

    public void PressLetter(string letter)
    {
        currentInput += letter;
        answerDisplay.text = currentInput;

        if (currentInput.Length == answer.Length)
            CheckAnswer();
    }

    void CheckAnswer()
    {
        if (currentInput == answer)
        {
            Debug.Log("Correct!");
            InventoryManager.Instance.AddItem(keyItem);
        }
        else
        {
            Debug.Log("Wrong! Resetting...");
            currentInput = "";
            answerDisplay.text = "";
        }
    }

    public void ClearInput()
    {
        currentInput = "";
        answerDisplay.text = "";
    }
}