using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathQuizManager : MonoBehaviour
{
    public MachineController machine;        // 머신 스크립트 연결
    public GameObject quizPanel;             // 퀴즈 패널
    public TMP_InputField answerInput;       // 입력창
    public TextMeshProUGUI questionText;     // 문제 텍스트
    private bool isQuizActive = false;

    private int num1, num2;                  // 문제 숫자
    private float cooldownTime = 5f;         // 퀴즈 재출제 쿨다운
    private float nextQuizTime;              // 다음 퀴즈 시간

    void Start()
    {
        quizPanel.SetActive(false);   // 처음엔 안보임
        nextQuizTime = Time.time + cooldownTime;
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });
    }

    void Update()
    {
        // 쿨다운 끝나면 퀴즈 재생성
        if (!quizPanel.activeSelf && Time.time > nextQuizTime)
        {
            ShowNewQuestion();
        }
    }

    void ShowNewQuestion()
    {
        // 문제 생성
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);
        questionText.text = $"{num1} + {num2} = ?";

        // 입력창 초기화 + 포커스
        answerInput.text = "";
        quizPanel.SetActive(true);
        answerInput.ActivateInputField();
        isQuizActive = true;   // ★★★ 중요!!
    }

    void CheckAnswer()
    {
        if (!isQuizActive) return;
        // 입력값 정수로 변환 시도
        if (int.TryParse(answerInput.text, out int answer))
        {
            if (answer == num1 + num2)
            {
                machine.Upgrade();   // 정답이면 업그레이드
                Debug.Log("정답! Speed +1");
            }
            else
            {
                Debug.Log("오답");
            }

            // 퀴즈 닫기 및 쿨다운 시작
            quizPanel.SetActive(false);
            nextQuizTime = Time.time + cooldownTime;
            isQuizActive = false;   // ★★★ 쿨다운 진입
        }
    }
}
