using JetBrains.Annotations;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public static PaintingManager Instance;
    public PaintingChanger[] paintings;
    public Animator doorAnimatior;

    void Awake()
    {
        Instance  = this;
    }

    public void CheckPuzzle()
    {
        foreach(PaintingChanger painting in paintings)
        {
            if (!painting.IsStopped())
            {
                return;
            }
        }
        foreach(PaintingChanger painting in paintings)
        {
            if (!painting.isCorrect())
            {
                Debug.Log("Wrong! Restarting");
                ResetAll();
                return;
            }
        }

       doorAnimatior.SetTrigger("Open");
       
    }

    void ResetAll()
    {
        foreach(PaintingChanger painting in paintings)
        {
            painting.Resume();
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
