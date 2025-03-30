using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // <-- ��� �߰�

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
        // ? UI�� �׻� �����ؾ� ȭ�鿡 ǥ�õ�
        timeLeft -= Time.deltaTime;

        timerText.text = "Time: " + Mathf.Ceil(timeLeft);
        scoreText.text = "Score: " + score;
        targetText.text = "Target: " + score + " / " + targetScore;

        // �ð� ��
        if (timeLeft <= 0)
        {
            if (score >= targetScore)
                stageClearPanel.SetActive(true);
            else
                gameOverPanel.SetActive(true);

            Time.timeScale = 0f; // ���� ����
        }
    }

    public void AddScore()
    {
        score++; // ������ ����
    }

    public void OverflowPenalty()
    {
        timeLeft -= 5f; // �����÷ο� �г�Ƽ
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
