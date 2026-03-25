using System;
using UnityEngine;

public class BatteryManipulator : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject Self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Self.gameObject.CompareTag("Increase"))
            gameManager.IncreaseBattery(10);
        if(other.gameObject.CompareTag("Player") && Self.gameObject.CompareTag("Decrease"))
            gameManager.DecreaseBattery(10);
    }
}
