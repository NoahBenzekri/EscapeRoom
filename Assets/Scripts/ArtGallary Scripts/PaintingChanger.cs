
using UnityEngine;

public class PaintingChanger : MonoBehaviour
{
    public Material[] Paintings;
    public Material correctPainting;
    public float Speed;
    public int materialSlot = 0;
    private int currentIndex = 0;
    private Renderer rend;
    private bool isStopped = false;
    private float timer;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= Speed)
        {
            timer = 0;
            currentIndex = (currentIndex+1) % Paintings.Length;
            Material[] mats = rend.materials;
            mats[materialSlot] = Paintings[currentIndex];
            rend.materials = mats;
        }
    }

    public void Stop()
    {
        isStopped = true;
        PaintingManager.Instance.CheckPuzzle();
    }

    public void Resume()
    {
        isStopped = false;

    }

    public bool isCorrect()
    {
        return rend.material.name == correctPainting.name+("(Instance)");

    }

    public bool IsStopped()
    {
        return isStopped;
    }
}
