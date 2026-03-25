using UnityEngine;

public class Atalho : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.hasBattery)
        {
            gameObject.SetActive(false);
        }

        if (gameManager.hasBattery)
        {
            gameObject.SetActive(true);
        }
    }
}
