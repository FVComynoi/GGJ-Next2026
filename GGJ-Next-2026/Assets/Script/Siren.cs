using System;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] GameObject[] atalhos;
    [SerializeField] Material materialEmit;
    [SerializeField] GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materialEmit.SetColor("_EmissionColor", Color.black);
    }

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        atalhos = GameObject.FindGameObjectsWithTag("Atalho");
        materialEmit = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.sirenActive)
        {
            foreach (GameObject activeAtalho in atalhos)
                activeAtalho.SetActive(false);
            materialEmit.SetColor("_EmissionColor", Color.red);

        }

        if (!gameManager.sirenActive)
        {
            foreach (GameObject activeAtalho in atalhos)
                activeAtalho.SetActive(true);
            materialEmit.SetColor("_EmissionColor", Color.black);
        }
    }
}
