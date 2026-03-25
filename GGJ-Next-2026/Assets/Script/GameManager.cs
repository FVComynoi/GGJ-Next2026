using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CounterText;
    [SerializeField] public float batteryCounter = 100f;
    public bool hasBattery = true;
    void Start()
    {
        batteryCounter = 100f;
    }
    void Update()
    {
        CounterText.text = batteryCounter.ToString("Bateria: 0");

        if (batteryCounter <= 0f)
        {
            batteryCounter = 0f;
            hasBattery = false;
        }
        if (batteryCounter >= 100f)
            batteryCounter = 100f;
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
