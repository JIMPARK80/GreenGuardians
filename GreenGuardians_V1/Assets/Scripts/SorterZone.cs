using UnityEngine;

public class SorterZone : MonoBehaviour
{
    public MachineController machine;
    public GameManager gameManager;
    public Transform overflowZone;

    private int currentCapacity = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            Debug.Log("처리됨");
            if (currentCapacity < machine.capacity)
            {
                currentCapacity++;
                Debug.Log("점수 올라감");
                gameManager.AddScore();
                currentCapacity--;  // ? 처리 후 즉시 비우기
            }
            else
            {
                // 오버플로우
                other.transform.position = overflowZone.position;
                gameManager.OverflowPenalty();
            }

            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        currentCapacity = 0; // 스테이지 클리어나 퀴즈 업그레이드 시 초기화 가능
    }
}
