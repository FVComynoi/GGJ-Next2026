using System;
using UnityEngine;

public class Farol : MonoBehaviour
{
    [Header("Headlight")]
    [SerializeField] private float elapsedTime =0;
    [SerializeField] private float swapDelay = 5;
    [SerializeField] private bool isRed = true;
    
    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Material[] farolMaterial;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        isRed = false;
        farolMaterial[0].color = Color.green;
        farolMaterial[1].color = Color.gray;
        farolMaterial[2].color = Color.gray;
    }
    
    void Update()
    {
        if (elapsedTime >= swapDelay - 1f && !isRed)
        {
            farolMaterial[0].color = Color.gray;
            farolMaterial[1].color = Color.yellow;
        }
        if (elapsedTime >= swapDelay)
        {
            elapsedTime = 0;
            if (isRed)
            {
                isRed = false;
                farolMaterial[2].color = Color.gray;
                farolMaterial[0].color = Color.green;
            }
            else if (!isRed)
            {
                isRed = true;
                farolMaterial[0].color = Color.gray;
                farolMaterial[1].color = Color.gray;
                farolMaterial[2].color = Color.red;
            }
        }
        elapsedTime += Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isRed)
                gameManager.DecreaseBattery(50);
            else if (!isRed)
                gameManager.IncreaseBattery(50);
                
        }
    }
}
