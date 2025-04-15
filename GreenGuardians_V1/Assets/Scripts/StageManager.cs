using UnityEngine;

public class StageManager : MonoBehaviour
{
    public MachineController machine; // Machine Controller Variable
    public GameManager gameManager; // Game Manager Variable

    [Header("Stage Info")] // Stage Info Header
    public int stage = 1; // Stage Number
    public int baseTargetScore = 10; // Base Target Score
    public float baseConveyorSpeed = 2f;

    private void Start() {
        ApplyStageSettings();
    }

    private void ApplyStageSettings() 
    {
        machine.speed = baseConveyorSpeed + (stage - 1); // Increase speed based on stage
        gameManager.targetScore = baseTargetScore + (stage - 1) * 10;  // Increase target score based on stage
        Debug.Log($"[StageManager] Stage {stage} 시작 | Speed: {machine.speed} | Target: {gameManager.targetScore}");

    }

    public void NextStage() 
    {
        stage++; // Increase stage
        ApplyStageSettings(); // Apply Stage Settings
    }

    public void ResetStage()
    {
        stage = 1; // Reset stage
        machine.ResetMachine(); // Reset Machine
        ApplyStageSettings(); // Apply Stage Settings
    }
    
}
