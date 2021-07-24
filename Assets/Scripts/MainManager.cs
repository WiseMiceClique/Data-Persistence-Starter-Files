using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Rigidbody Ball;
    public HUD hud;
    public GameSaver gameSaver;
    public string playerName;
    private bool m_Started = false;
    private int m_Points = 0;
    private int bestPoints = 0;
    private bool m_GameOver = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gameSaver = FindObjectOfType<GameSaver>();
        hud = FindObjectOfType<HUD>();
        SaveData saveData = gameSaver.LoadScore();
        bestPoints = saveData.score;
        playerName = saveData.name;
        hud.UpdateHighScore(saveData.name, saveData.score);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SaveData saveData = gameSaver.LoadScore();
        bestPoints = saveData.score;
        playerName = saveData.name;
        hud.UpdateHighScore(playerName, bestPoints);
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = false;
                m_GameOver = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddPoint(int point)
    {
        m_Points += point;

        if (m_Points > bestPoints)
        {
            bestPoints = m_Points;
        }

        hud.UpdateScore();
        hud.UpdateHighScore(playerName, bestPoints);
    }

    public void GameOver()
    {
        hud.EndGameDisplay();
        m_GameOver = true;
        m_Points = 0;
        gameSaver.SaveScore(playerName, bestPoints);
    }

    public int GetCurrentScore() //ENCAPSULATION
    {
        return m_Points;
    }

    public int GetCurrentHighScore() //ENCAPSULATION
    {
        return bestPoints;
    }
}
