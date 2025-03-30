using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // <-- 요거 추가

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text targetText;

    public GameObject stageClearPanel;
    public GameObject gameOverPanel;

    public int targetScore = 20;
    public float timeLeft = 60f;

    private int score = 0;

    void Update()
    {
        // ? UI를 항상 갱신해야 화면에 표시됨
        timeLeft -= Time.deltaTime;

        timerText.text = "Time: " + Mathf.Ceil(timeLeft);
        scoreText.text = "Score: " + score;
        targetText.text = "Target: " + score + " / " + targetScore;

        // 시간 끝
        if (timeLeft <= 0)
        {
            if (score >= targetScore)
                stageClearPanel.SetActive(true);
            else
                gameOverPanel.SetActive(true);

            Time.timeScale = 0f; // 게임 정지
        }
    }

    public void AddScore()
    {
        score++; // 점수만 증가
    }

    public void OverflowPenalty()
    {
        timeLeft -= 5f; // 오버플로우 패널티
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
