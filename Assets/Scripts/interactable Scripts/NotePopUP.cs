using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.UI;


public class NotePopUp : MonoBehaviour
{
    public static NotePopUp Instance;
    public Transform holdPoint;
    public PlayerMovement movement;
    public MouseLook look;

    Vector3 startPos;
    Quaternion startRot;
    Transform startParent;

    bool open;

    void Awake()
    {
        gameObject.SetActive(true);
        Instance = this;
    }
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        startParent = transform.parent;
    }

    void Update()
    {
        if (open && Input.GetKeyDown(KeyCode.Escape))
            CloseNote();
    }

    public void PopUpToFace()
    {
        gameObject.SetActive(true);
        Interactable.EnterZoomMode();
        open = true;

        movement.enabled = false;
        look.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void CloseNote()
    {
        gameObject.SetActive(false);
        Interactable.ExitZoomMode();
        open = false;

        transform.SetParent(startParent);
        transform.position = startPos;
        transform.rotation = startRot;

        movement.enabled = true;
        look.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}