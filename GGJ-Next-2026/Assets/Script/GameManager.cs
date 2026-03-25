using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CounterText;
    [SerializeField] public float batteryCounter = 100f;
    private bool hasBattery = true;
    public bool sirenActive = false;

    void Start()
    {
        batteryCounter = 100f;
        sirenActive = false;
    }

    void Update()
    {
        CounterText.text = batteryCounter.ToString("Bateria: 0");

        if (batteryCounter <= 0f)
        {
            batteryCounter = 0f;
            hasBattery = false;
            sirenActive = false;
        }
        else if (batteryCounter > 0f)
        {
            hasBattery = true;

        }

        if (batteryCounter >= 100f)
            batteryCounter = 100f;

        if (Input.GetKeyDown(KeyCode.R) && hasBattery && batteryCounter == 100f)
        {
            sirenActive = true;
        }

        if (sirenActive)
            batteryCounter -= Time.deltaTime * 15f;
    }

    public void DecreaseBattery(float amount)
    {
        batteryCounter -= amount;
    }

    public void IncreaseBattery(float amount)
    {
        batteryCounter += amount;
    }
}
