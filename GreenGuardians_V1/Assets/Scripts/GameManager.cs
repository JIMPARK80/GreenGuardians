using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace
using TMPro; // TextMeshPro 관련 네임스페이스 / TextMeshPro Related Namespace
using UnityEngine.SceneManagement; // 씬 전환 관련 네임스페이스 / Scene Change Related Namespace

public class GameManager : MonoBehaviour // 게임 매니저 클래스 / Game Manager Class
{
    public TMP_Text timerText, scoreText, targetText, overflowText; // 텍스트 표시 관련 변수 / Text Display Related Variables
    public GameObject stageClearPanel, gameOverPanel; // 패널 표시 관련 변수 / Panel Display Related Variables

    [Header("Stage Settings")] // 스테이지 설정 관련 헤더 / Stage Settings Related Header
    public int targetScore = 10; // 목표 점수 / Target Score
    public float timeLimit = 60f; // 시간 제한 / Time Limit

    private int score = 0; // 점수 변수 / Score Variable
    private int overflowCount = 0; // 오버플로우 카운트 변수 / Overflow count variable
    public float timeLeft; // 남은 시간 변수 / Remaining time variable

    void Start() // 게임 시작 시 초기화 / Initialize when the game starts
    {
        Time.timeScale = 1f; // 게임 시작할 때 시간 스케일 초기화
        timeLeft = timeLimit; // 시간 초기화 / Initialize time
        UpdateUI(); // UI 업데이트 / Update UI
        stageClearPanel.SetActive(false); // 스테이지 클리어 패널 비활성화 / Disable stage clear panel
        gameOverPanel.SetActive(false); // 게임 오버 패널 비활성화 / Disable game over panel
    }

    void Update() // 게임 진행 중 업데이트 / Update during the game
    {
        timeLeft -= Time.deltaTime; // 시간 감소 / Decrease time
        UpdateUI(); // UI 업데이트 / Update UI

        if (timeLeft <= 0) // 시간 종료 시
        {
            if (score >= targetScore) stageClearPanel.SetActive(true); // 목표 점수 달성 시 스테이지 클리어 패널 활성화 / Activate stage clear panel if target score is reached
            else gameOverPanel.SetActive(true); // 목표 점수 달성 시 게임 오버 패널 활성화 / Activate game over panel if target score is not reached

            Time.timeScale = 0f; // 게임 일시정지 / Pause the game
        }
    }

    public void AddScore() // 점수 증가 / Increase score
    {
        score++; // 점수 증가 / Increase score
        UpdateUI(); // UI 업데이트 / Update UI
    }

    public void OverflowPenalty() //
    {
        overflowCount++; // 오버플로우 카운트 증가 / Increase overflow count
        timeLeft -= 0f;// 시간 감소 / Decrease time
        UpdateUI(); // UI 업데이트 / Update UI
    }
 
    public void NextStage() // 다음 스테이지 로드 / Load the next stage
    {
        SceneManager.LoadScene("MainScene"); // Change to your real game scene name
        Time.timeScale = 1f; // << 반드시 추가
    }

    private void UpdateUI() // UI 업데이트 / Update UI
    {
        timerText.text = "Time: " + Mathf.Ceil(timeLeft); // 시간 표시 / Display time
        scoreText.text = "Score: " + score; // 점수 표시 / Display score
        targetText.text = "Target: " + score + " / " + targetScore; // 목표 점수 표시 / Display target score
        overflowText.text = "Overflow: " + overflowCount; // 오버플로우 카운트 표시 / Display overflow count
    }

    public void Retry() // 게임 재시작 / Retry the game
    {
        SceneManager.LoadScene("MainScene"); // Change to your real game scene name
        Time.timeScale = 1f; // << 반드시 추가
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("GameStart");
        Time.timeScale = 1f;  // 중요!! 멈춤 풀기
    }
}
