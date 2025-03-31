using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace

public class MachineController : MonoBehaviour // 기계 컨트롤러 클래스 / Machine Controller Class
{
    public float speed = 1.0f;  // 처리 속도만 남김
    
    public void Upgrade()
    {
        speed += 0.5f;  // 퀴즈 맞출 때마다 속도만 증가
        Debug.Log($"Machine Speed Upgraded: {speed:F1}");
    }

    public void ResetMachine()
    {
        speed = 1.0f;  // 초기화도 속도만
    }
}
