using System;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] GameObject[] atalhos;
    [SerializeField] Material material;
    [SerializeField] GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        atalhos = GameObject.FindGameObjectsWithTag("Atalho");
        material = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.sirenActive)
        {
            foreach (GameObject activeAtalho in atalhos)
                activeAtalho.SetActive(false);
            material.color = Color.red;
        }

        if (!gameManager.sirenActive)
        {
            foreach (GameObject activeAtalho in atalhos)
                activeAtalho.SetActive(true);
            material.color = Color.gray;
        }
    }
}
