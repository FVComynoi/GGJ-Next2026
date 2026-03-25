using System;
using UnityEngine;
using TMPro;

public class Tutorials : MonoBehaviour
{
    [SerializeField] GameObject MoveTutorial;
    [SerializeField] GameObject SirenTutorial;

private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            MoveTutorial.SetActive(true);
        }
    }
}
