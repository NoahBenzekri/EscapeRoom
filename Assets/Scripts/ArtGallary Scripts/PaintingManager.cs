using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public static PaintingManager Instance;
    public PaintingChanger[] paintings;
    public GameObject door;

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

        door.SetActive(false);

        //// door opens need to add animaton
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
