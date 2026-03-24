using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CounterText;
    [SerializeField] public float batteryCounter = 100f;
    private bool hasBattery = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        batteryCounter = 100f;
    }

    // Update is called once per frame
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
    [ContextMenu("DecreaseBattery")]
    public void DecreaseBattery(float amount)
    {
        batteryCounter -= amount;
    }

    public void IncreaseBattery(float amount)
    {
        batteryCounter += amount;
    }
}
