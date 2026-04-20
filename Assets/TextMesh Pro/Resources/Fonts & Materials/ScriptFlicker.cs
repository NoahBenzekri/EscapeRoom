using UnityEngine;
using TMPro;
using System.Collections;

public class ScriptFlicker : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public Color flickerColor = Color.red;

    void Start()
    {
        titleText.color = flickerColor;
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            titleText.alpha = 1f;
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));

            // flicker burst
            int flickers = Random.Range(2, 5);
            for (int i = 0; i < flickers; i++)
            {
                titleText.alpha = Random.Range(0.1f, 0.4f);
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                titleText.alpha = 1f;
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            }
        }
    }
}