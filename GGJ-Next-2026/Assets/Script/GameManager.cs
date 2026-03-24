using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CounterText;
    [SerializeField] public float batteryCounter = 100f;
    [SerializeField] private GameObject shortcut;
    private bool hasBattery;
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
            shortcut.SetActive(true);
        }

        while (batteryCounter >= 100f)
        {
            if ( batteryCounter==100f && Input.GetKey(KeyCode.Q)) 
            {
                hasBattery = true;
            }
            //if (hasBattery = true)
            //{
                //shortcut.SetActive(false);
            //}
        }
            
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
