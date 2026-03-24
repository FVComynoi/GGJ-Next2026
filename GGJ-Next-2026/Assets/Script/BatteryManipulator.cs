using System;
using UnityEngine;

public class BatteryManipulator : MonoBehaviour
{
    [SerializeField] private GameObject Self;
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Self.gameObject.CompareTag("Increase")) 
            gameManager.IncreaseBattery(10);
        if (other.gameObject.CompareTag("Player") && Self.gameObject.CompareTag("Decrease"))
            gameManager.DecreaseBattery(10);

    }
}
