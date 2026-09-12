using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int totalKoin; 
    private int koinTerkumpul = 0; 
    public GameObject winPanel; // Panel untuk menampilkan kemenangan
    public static GameManager Instance;

    public GameState currentState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentState = GameState.Playing;
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                PauseGame();
            }
            else if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        currentState = GameState.Paused;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0f;
        currentState = GameState.GameOver;
    }

    public void AmbilKoin() 
    { 
        koinTerkumpul++; 
        // TODO: jika koinTerkumpul == totalKoin, panggil Menang() 
        if ( koinTerkumpul == totalKoin) Menang(); 
    }

    void Menang() 
    { 
        Debug.Log("KAMU MENANG!"); 
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    } 
}