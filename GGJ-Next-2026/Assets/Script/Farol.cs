using System;
using UnityEngine;

public class Farol : MonoBehaviour
{
    [SerializeField] private float elapsedTime =0;
    [SerializeField] private float swapDelay = 5;
    [SerializeField] private bool isRed = true;
    [SerializeField] private Material[] farolMaterial;


    private void Awake()
    {
        
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
                Debug.Log("Passou o farol vermelho, VSFD");
            else if (!isRed)
                Debug.Log("Farol Verde");
                
        }
    }
}
