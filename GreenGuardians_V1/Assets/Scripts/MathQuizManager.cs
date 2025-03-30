using UnityEngine;
using UnityEngine.UI;

public class MathQuizManager : MonoBehaviour
{
    public Text quizText;
    public InputField inputField;
    public MachineController machine;

    private int answer;

    private void Start()
    {
        GenerateQuiz();
    }

    void GenerateQuiz()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        answer = a + b;
        quizText.text = $"{a} + {b} = ?";
    }

    public void CheckAnswer()
    {
        if (int.TryParse(inputField.text, out int userAnswer) && userAnswer == answer)
        {
            machine.Upgrade();
            Debug.Log("정답! 업그레이드");
        }
        inputField.text = "";
        GenerateQuiz();
    }
}
