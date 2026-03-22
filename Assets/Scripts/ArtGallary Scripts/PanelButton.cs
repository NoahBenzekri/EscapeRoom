using UnityEngine;

public class PanellButton : MonoBehaviour
{
    public PaintingChanger targetPainting;

    public void OnMouseDown()
    {
        if (targetPainting.IsStopped())
        {
            targetPainting.Resume();
        }
        else
        {
            targetPainting.Stop();
        }
    }
}
