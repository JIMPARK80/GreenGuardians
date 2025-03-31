using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace
using UnityEngine.UI; //

public class MathQuizManager : MonoBehaviour // 수학 퀴즈 매니저 클래스 / Math Quiz Manager Class
{
    public Text quizText; // 퀴즈 텍스트 변수 / Quiz Text Variable
    public InputField inputField; // 입력 필드 변수 / Input Field Variable
    public MachineController machine; // 기계 컨트롤러 변수 / Machine Controller Variable

    private int answer; // 정답 변수 / Answer Variable

    private void Start() // 시작 시 퀴즈 생성 / Generate quiz when starting
    {
        GenerateQuiz(); // 퀴즈 생성 / Generate quiz
    }

    void GenerateQuiz()
    {
        int a = Random.Range(1, 10); // 1부터 9 사이의 랜덤 숫자 생성 / Generate random number between 1 and 9
        int b = Random.Range(1, 10); // 1부터 9 사이의 랜덤 숫자 생성 / Generate random number between 1 and 9
        answer = a + b; // 정답 계산 / Calculate answer
        quizText.text = $"{a} + {b} = ?"; // 퀴즈 텍스트 업데이트 / Update quiz text
    }

    public void CheckAnswer() // 정답 확인 / Check answer
    {
        if (int.TryParse(inputField.text, out int userAnswer) && userAnswer == answer) // 입력한 값이 정수이고 정답인 경우
        {
            machine.Upgrade(); // 기계 업그레이드 / Upgrade machine
            Debug.Log("Correct answer! Machine upgraded"); // 정답 로그 출력 / Log answer
        }
        inputField.text = ""; // 입력 필드 초기화 / Clear input field
        GenerateQuiz(); // 퀴즈 생성 / Generate quiz
    }
}
