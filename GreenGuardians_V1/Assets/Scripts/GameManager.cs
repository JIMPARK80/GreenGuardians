using UnityEngine; // Unity Engine Related Namespace
using TMPro; // TextMeshPro Related Namespace
using UnityEngine.SceneManagement; // Scene Change Related Namespace

public class GameManager : MonoBehaviour // Game Manager Class
{
    public TMP_Text timerText, scoreText, targetText, overflowText; // Text Display Related Variables
    public GameObject stageClearPanel, gameOverPanel; // Panel Display Related Variables

    [Header("Stage Settings")] // Stage Settings Related Header
    public int targetScore = 10; // Target Score
    public float timeLimit = 60f; // Time Limit

    private int score = 0; // Score Variable
    private int overflowCount = 0; // Overflow count variable
    public float timeLeft; // Remaining time variable
    public int quizScore = 0;

    void Start() // Initialize when the game starts
    {
        Time.timeScale = 1f; // Initialize when the game starts
        timeLeft = timeLimit; // Initialize time
        UpdateUI(); // Update UI
        stageClearPanel.SetActive(false); // Disable stage clear panel
        gameOverPanel.SetActive(false); // Disable game over panel
    }

    void Update() // Update during the game
    {
        timeLeft -= Time.deltaTime; // Decrease time
        UpdateUI(); // Update UI

        if (timeLeft <= 0) // When time is over
        {
            if (score >= targetScore)
            {
                stageClearPanel.SetActive(true); // Activate stage clear panel if target score is reached
            }
            else
            {
                gameOverPanel.SetActive(true); // Activate game over panel if target score is not reached
            } 

            Time.timeScale = 0f; // Pause the game
        }
    }

    public void AddScore() // Increase score
    {
        score++; // Increase score
        UpdateUI(); // Update UI
    }

    public void OverflowPenalty() // Increase overflow count    
    {
        overflowCount++; // Increase overflow count
        timeLeft -= 0f;// Decrease time
        UpdateUI(); // Update UI
    }
 
    public void NextStage() // Load the next stage
    {
        SceneManager.LoadScene("MainScene"); // Change to your real game scene name
        Time.timeScale = 1f; //     
    }

    private void UpdateUI() // Update UI
    {
        timerText.text = "Time: " + Mathf.Ceil(timeLeft); // Display time
        scoreText.text = "Score: " + score; // Display score
        targetText.text = "Target: " + score + "/" + targetScore; // Display target score
        overflowText.text = "Overflow: " + overflowCount; // Display overflow count
    }

    public void Retry() // Retry the game
    {
        SceneManager.LoadScene("MainScene"); // Change to your real game scene name
        Time.timeScale = 1f; // 
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("GameStart");
        Time.timeScale = 1f;  // 
    }

    public bool UseSkill(int cost)
    {
        if (quizScore >= cost)
        {
            quizScore -= cost;
            Debug.Log($"Skill used! Remaining points: {quizScore}");
            return true;
        }
        else
        {
            Debug.Log("Not enough points");
            return false;
        }
    }


}
