using System.Runtime.CompilerServices;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(4.402f, 0.9630002f, -14.41f);
        }
    }
}
