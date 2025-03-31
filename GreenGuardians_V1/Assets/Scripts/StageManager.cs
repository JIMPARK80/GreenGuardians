using UnityEngine;

public class StageManager : MonoBehaviour
{
    public MachineController machine; // 기계 컨트롤러 변수 / Machine Controller Variable
    public GameManager gameManager; // 게임 매니저 변수 / Game Manager Variable

    [Header("Stage Info")] // 스테이지 정보 헤더 / Stage Info Header
    public int stage = 1; // 스테이지 번호 / Stage Number
    public int baseTargetScore = 10; // 기본 목표 점수 / Base Target Score
    public float baseConveyorSpeed = 2f;

    private void Start() {
        ApplyStageSettings();
    }

    private void ApplyStageSettings() 
    {
        machine.speed = baseConveyorSpeed + (stage - 1); // Stage별 속도 증가
        gameManager.targetScore = baseTargetScore + (stage - 1) * 10;  // Stage별 목표점수 증가
        Debug.Log($"[StageManager] Stage {stage} 시작 | Speed: {machine.speed} | Target: {gameManager.targetScore}");

    }

    public void NextStage() 
    {
        stage++; // 스테이지 증가 / Stage Increase
        ApplyStageSettings(); // 스테이지 설정 적용 / Apply Stage Settings
    }

    public void ResetStage()
    {
        stage = 1; // 스테이지 초기화 / Stage Reset
        machine.ResetMachine(); // 기계 초기화 / Reset Machine
        ApplyStageSettings(); // 스테이지 설정 적용 / Apply Stage Settings
    }
    
}
