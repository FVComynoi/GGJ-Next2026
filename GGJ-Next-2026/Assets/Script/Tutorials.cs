using System;
using UnityEngine;
using TMPro;

public class Tutorials : MonoBehaviour
{
    [SerializeField] GameObject MoveTutorial;
    [SerializeField] GameObject SirenTutorial;
    [SerializeField] GameObject trafficTutorial;

private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("GameController"))
        {
            MoveTutorial.SetActive(true);
            Destroy(MoveTutorial,3.5f);
        }

        if (collider.CompareTag("SirenTutorial"))
        {
            SirenTutorial.SetActive(true);
            Destroy(SirenTutorial,4.5f);
        }

        if (collider.CompareTag("TrafficTutorial"))
        {
            trafficTutorial.SetActive(true);
            Destroy(trafficTutorial,3.5f);
        }
    }
}
