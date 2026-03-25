using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Battery References")]
    [SerializeField] TextMeshProUGUI CounterText;
    [SerializeField] Image batteryImage;
    [SerializeField] private Sprite[] images;
    
    [Header("Timer")]
    [SerializeField] TextMeshProUGUI TimerText;
    public float elapsedTime = 0f;
    
    [Header("Battery")]
    [SerializeField] public float batteryCounter = 100f;
    public bool sirenActive = false;
    private bool hasBattery = true;

    void Start()
    {
        batteryCounter = 100f;
        sirenActive = false;
    }

    void Update()
    {
        DisplayTime(elapsedTime);
        DisplayBattery(batteryCounter);

        if (batteryCounter <= 0f)
        {
            batteryCounter = 0f;
            hasBattery = false;
            sirenActive = false;
        }
        else if (batteryCounter > 0f)
        {
            hasBattery = true;
            batteryImage.sprite = images[0];
        }

        if (batteryCounter >= 100f)
            batteryCounter = 100f;

        if (Input.GetKeyDown(KeyCode.Q) && hasBattery && batteryCounter == 100f)
        {
            sirenActive = true;
        }

        if (sirenActive)
            batteryCounter -= Time.deltaTime * 15f;

        if (batteryCounter < 100f && !sirenActive)
        {
            batteryImage.sprite = images[1];
        }
    }

    public void DecreaseBattery(float amount)
    {
        batteryCounter -= amount;
    }

    public void IncreaseBattery(float amount)
    {
        batteryCounter += amount;
    }

    private void DisplayTime(float timeToDisplay)
    {
        elapsedTime += Time.deltaTime;
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        TimerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    void DisplayBattery(float batteryRemaining)
    {
        CounterText.text = batteryRemaining.ToString($"Battery: 0");
        batteryImage.fillAmount = batteryRemaining / 100f;
    }
}
