using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleQuiz : MonoBehaviour
{
    public GameObject quizPanel; // quiz panel          
    public TMP_InputField answerInput; // input field
    public TextMeshProUGUI questionText; // question text
    public TextMeshProUGUI scoreText;  // display score
    public Button submitButton;  // submit button

    private int num1, num2;
    private int score = 0;  // score variable
    private float cooldownTime = 3f; // cooldown time
    private float nextQuizTime; // next quiz time
    private bool isQuizActive = true; // quiz active

    public void Start()
    {
        // connect button click event
        submitButton.onClick.AddListener(CheckAnswer);
        ShowNewQuestion();
        UpdateScoreText();
    }

    public void Update()
    {
        // after cooldown, show new question
        if (!quizPanel.activeSelf && Time.time >= nextQuizTime)
        {
            ShowNewQuestion();
        }

        // automatically focus on input field
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
                Debug.Log($"Correct! Current score: {score}");
                ShowNewQuestion();  // show new question immediately
            }
            else
            {
                Debug.Log($"Wrong! The answer is {num1 + num2}.");
                answerInput.text = "";  // if wrong, only reset input field
                answerInput.ActivateInputField();
            }
        }
        else
        {
            Debug.Log("Please enter a number!");
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
