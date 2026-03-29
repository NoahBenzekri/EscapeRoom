using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad1 : MonoBehaviour
{

    [Header("Objects to Hide/Show")]



    public GameObject objectToEnable;


    [Header("Keypad Settings")]
    public string curPassword = "59718";
    public string input;
    public Text displayText;
    public AudioSource audioData;
    public Animator doorAnimator;


    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;


    void Start()
    {
        btnClicked = 0;
        numOfGuesses = curPassword.Length;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click check");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad2"))
                {
                    Debug.Log("keypad clicked");
                    keypadScreen = true;


                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }


        if (keypadScreen)
        {
            objectToEnable.SetActive(true);
        }


        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                Debug.Log("Correct Password!");


                if (doorAnimator != null)
                    doorAnimator.SetTrigger("Open");


                objectToEnable.SetActive(false);
                keypadScreen = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;


                input = "";
                btnClicked = 0;
            }
            else
            {

                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }
        }
    }



    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":

                objectToEnable.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C":
                input = "";
                btnClicked = 0;
                displayText.text = input.ToString();
                break;

            default:
                btnClicked++;
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
