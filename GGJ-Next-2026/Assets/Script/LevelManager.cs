using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject gameEndScreen;
    [SerializeField] GameObject playButton;
    
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        Time.timeScale = 0f;
        gameEndScreen.SetActive(false);
        playButton.SetActive(true);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameEnd();
        }
    }
    public void GameEnd()
    {
        gameEndScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnPlay()
    {
        playButton.SetActive(false);
        Time.timeScale = 1f;
        music.Play();
    }        
    public void ReplayGame()
    {
        SceneManager.LoadScene("Stage");
    }
}
