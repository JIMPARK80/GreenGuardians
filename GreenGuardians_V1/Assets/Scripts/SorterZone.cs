using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace

public class SorterZone : MonoBehaviour // 정렬 존 클래스 / Sorter Zone Class
{
    public MachineController machine; // 기계 컨트롤러 변수 / Machine Controller Variable
    public GameManager gameManager; // 게임 매니저 변수 / Game Manager Variable

    [Header("Stage level settings")] // 스테이지 레벨 설정 관련 헤더 / Stage level settings related header
    public float sortCooldown = 2f; // 정렬 쿨다운 시간 / Sort cooldown time
    private float lastSortTime = 1f; // 마지막 정렬 시간 / Last sort time

    private void OnTriggerEnter2D(Collider2D other) // 충돌 시 호출되는 함수 / Function called when collision occurs
    {
        if (!other.CompareTag("Trash")) return; // 충돌한 객체가 쓰레기가 아닌 경우 반환 / Return if the collided object is not trash

        Trash trash = other.GetComponent<Trash>(); // 쓰레기 컴포넌트 가져오기 / Get trash component

        // 기계 용량이 0보다 크고 마지막 정렬 시간이 정렬 쿨다운 시간보다 크거나 같은 경우
        if (machine.capacity > 0 && Time.time - lastSortTime >= sortCooldown)
        {
            lastSortTime = Time.time; // 마지막 정렬 시간 업데이트 / Update last sort time
            machine.capacity--; // 기계 용량 감소 / Decrease machine capacity
            trash.StartSorting(); // 쓰레기 정렬 시작 / Start sorting trash
            gameManager.AddScore(); // 점수 증가 / Increase score
        }
        else
        {
            // 기계 용량이 0보다 작거나 마지막 정렬 시간이 정렬 쿨다운 시간보다 작은 경우
            trash.StartOverflow(); // 오버플로우 시작 / Start overflow
        }
    }
}
