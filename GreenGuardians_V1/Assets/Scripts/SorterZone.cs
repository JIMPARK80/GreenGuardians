using UnityEngine;

public class SorterZone : MonoBehaviour
{
    public MachineController machine;
    public GameManager gameManager;

    [Header("Stage level settings")]
    public float sortCooldown = 2f;
    private float lastSortTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Trash")) return;

        Trash trash = other.GetComponent<Trash>();

        // 정상 처리 가능한 경우
        if (machine.capacity > 0 && Time.time - lastSortTime >= sortCooldown)
        {
            lastSortTime = Time.time;
            machine.capacity--;
            trash.StartSorting(); // 초록색 변경
            gameManager.AddScore();
        }
        else
        {
            // 처리 불가 상태에서는 바로 overflow 후보로 색상만 붉게 변경
            trash.StartOverflow(); // 붉은색 변경만 하고 대기 (실제 overflow는 아님)
        }
    }
}
