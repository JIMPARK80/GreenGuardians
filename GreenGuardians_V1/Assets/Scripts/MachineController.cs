using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace

public class MachineController : MonoBehaviour // 기계 컨트롤러 클래스 / Machine Controller Class
{
    public float speed = 1.0f; // 기계 속도 / Machine speed
    public float capacity = 1.0f; // 기계 용량 / Machine capacity

    public void Upgrade() // 기계 업그레이드 / Upgrade machine
    {
        speed += 0.5f; // 속도 증가 / Increase speed
        capacity += 0.5f; // 용량 증가 / Increase capacity
    }
}
