using System.Collections;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    public GameObject txtToDisplay;
    private bool PlayerInZone;

    public GameObject[] lights; 

    private Coroutine lightCoroutine;

    private void Start()
    {
        PlayerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLights();
        }
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("F pressed");
            ActivateLights();
        }
    }

    void ActivateLights()
    {
        // turn ON all lights
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }

        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().Play("switch");

        // restart timer if spamming
        if (lightCoroutine != null)
            StopCoroutine(lightCoroutine);

        lightCoroutine = StartCoroutine(TurnOffLightsAfterDelay());
    }

    IEnumerator TurnOffLightsAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3f);

        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
}