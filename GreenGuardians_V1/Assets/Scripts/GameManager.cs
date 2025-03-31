using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText, scoreText, targetText, overflowText;
    public GameObject stageClearPanel, gameOverPanel;

    [Header("Stage Settings")]
    public int targetScore = 10;
    public float timeLimit = 60f;

    private int score = 0;
    private int overflowCount = 0;
    private float timeLeft;

    void Start()
    {
        timeLeft = timeLimit;
        UpdateUI();
        stageClearPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        UpdateUI();

        if (timeLeft <= 0)
        {
            if (score >= targetScore) stageClearPanel.SetActive(true);
            else gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void AddScore()
    {
        score++;
        UpdateUI();
    }

    public void OverflowPenalty()
    {
        overflowCount++;
        timeLeft -= 0f;
        UpdateUI();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeLeft);
        scoreText.text = "Score: " + score;
        targetText.text = "Target: " + score + " / " + targetScore;
        overflowText.text = "Overflow: " + overflowCount;
    }
}
