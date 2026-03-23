using System;
using UnityEngine;

public class Farol : MonoBehaviour
{
    [SerializeField] private float elapsedTime =0;
    [SerializeField] private float swapDelay = 5;
    [SerializeField] private bool isRed= true;
    [SerializeField] private Material farolMaterial;


    private void Awake()
    {
        farolMaterial = GetComponent<MeshRenderer>().material;
    }

    void Start()
    {
        isRed = true;
    }
    
    void Update()
    {
        if (elapsedTime >= swapDelay)
        {
            elapsedTime = 0;
            if (isRed)
            {
                isRed = false;
                farolMaterial.color = Color.green;
            }
            else if (!isRed)
            {
                isRed = true;
                farolMaterial.color = Color.red;
            }
        }
        elapsedTime += Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            Debug.Log("Passou pelo farol");
    }
}
