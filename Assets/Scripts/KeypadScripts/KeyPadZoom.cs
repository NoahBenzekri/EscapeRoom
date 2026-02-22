using UnityEngine;

public class KeypadZoom : MonoBehaviour
{
    public Transform zoomPoint;
    public Transform cameraTransform;
    public PlayerMovement movement;
    public MouseLook look;

    Vector3 startPos;
    Quaternion startRot;
    Transform startParent;
    bool zoomed;

    void Update()
    {
        if (zoomed && Input.GetKeyDown(KeyCode.Escape))
            ExitZoom();
    }
    public void EnterZoom()
    {
        if (zoomed) return;
        zoomed = true;

        Interactable.EnterZoomMode();

        startPos = cameraTransform.localPosition;
        startRot = cameraTransform.localRotation;

        movement.enabled = false;
        look.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        cameraTransform.position = zoomPoint.position;
        cameraTransform.rotation = zoomPoint.rotation;
    }

    public void ExitZoom()
    {
        if (!zoomed) return;
        zoomed = false;

        Interactable.ExitZoomMode();

    
        cameraTransform.localPosition = startPos;
        cameraTransform.localRotation = startRot;

        movement.enabled = true;
        look.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}