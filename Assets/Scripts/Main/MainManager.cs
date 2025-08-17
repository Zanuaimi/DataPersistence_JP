using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        UpdateBestScoreText();
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
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
            // For Restart
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
        EscKey();
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{SceneFlower.instance.Name} Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        UpdateBestScoreText();
        UpdateInfoGame();
    }

    // GameOver screen if esc during match, back to menu if esc in gameover screen

    private void EscKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_GameOver == false)
        {
            GameOver();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && m_GameOver == true)
        {
            BackToStart();
        }
    }

    // Load the best score and name when loaded into the game

    void UpdateBestScoreText()
    {
        BestScoreText.text = "Best Score : " + SceneFlower.instance.BestName + " : " + SceneFlower.instance.Highscore; // Access to the variables from static instance variable from SceneFlower class
    }

    void UpdateInfoGame()
    {
        SceneFlower.instance.UpdateBest(m_Points, SceneFlower.instance.Name);
    }

    void BackToStart()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
}
