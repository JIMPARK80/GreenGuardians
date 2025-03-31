using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace

public class OverflowZone : MonoBehaviour // 오버플로우 존 클래스 / Overflow Zone Class
{
    public GameManager gameManager; // 게임 매니저 변수 / Game Manager Variable

    private void OnTriggerEnter2D(Collider2D other) // 충돌 시 호출되는 함수 / Function called when collision occurs
    {
        if (other.CompareTag("Trash")) // 충돌한 객체가 쓰레기인 경우
        {
            gameManager.OverflowPenalty(); // 오버플로우 패널티 적용 / Apply overflow penalty
            Destroy(other.gameObject); // 쓰레기 객체 삭제 / Destroy trash object
        }
    }
}
