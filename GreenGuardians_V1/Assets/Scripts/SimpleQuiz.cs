using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleQuiz : MonoBehaviour
{
    public GameObject quizPanel;
    public TMP_InputField answerInput;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;  // 점수 표시용 텍스트
    public Button submitButton;  // 제출 버튼 추가

    private int num1, num2;
    private int score = 0;  // 점수 변수 추가
    private float cooldownTime = 3f;
    private float nextQuizTime;
    private bool isQuizActive = true;

    public void Start()
    {
        // 버튼 클릭 이벤트 연결
        submitButton.onClick.AddListener(CheckAnswer);
        ShowNewQuestion();
        UpdateScoreText();
    }

    public void Update()
    {
        // 쿨다운 후 새 문제 표시
        if (!quizPanel.activeSelf && Time.time >= nextQuizTime)
        {
            ShowNewQuestion();
        }

        // 입력 필드 자동 포커스
        if (!answerInput.isFocused && quizPanel.activeSelf)
        {
            answerInput.ActivateInputField();
        }
    }

    public void ShowNewQuestion()
    {
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);
        questionText.text = $"{num1} + {num2} = ?";
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    public void CheckAnswer()
    {
        if (int.TryParse(answerInput.text, out int answer))
        {
            bool isCorrect = (answer == num1 + num2);

            if (isCorrect)
            {
                score++;
                UpdateScoreText();
                Debug.Log($"정답! 현재 점수: {score}");
                ShowNewQuestion();  // 바로 새로운 문제 표시
            }
            else
            {
                Debug.Log($"오답! 정답은 {num1 + num2}입니다.");
                answerInput.text = "";  // 오답인 경우 입력 필드만 초기화
                answerInput.ActivateInputField();
            }
        }
        else
        {
            Debug.Log("숫자를 입력해주세요!");
            answerInput.text = "";
            answerInput.ActivateInputField();
        }
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Skill Point: {score}";
        }
    }
}
