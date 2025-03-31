using UnityEngine;

public class SorterZone : MonoBehaviour
{
    public MachineController machine;
    public GameManager gameManager;
    public Transform overflowZone;

    private int currentCapacity = 0;
    private float capacityCooldown = 0.5f; // 쓰레기 하나 처리 후 0.5초 뒤에 capacity -1
    private float capacityTimer = 0f;

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
                other.GetComponent<Trash>().StartSorting();
                // Destroy() 안함
            }
            else
            {
                // 오버플로우
                Debug.Log("overflow +1");
                gameManager.OverflowPenalty();
                other.GetComponent<Trash>().StartOverflow(); // 오른쪽으로 이동
                // Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        // capacity 자연 감소 (공장이 시간이 지나면 비워지는 느낌)
        if (currentCapacity > 0)
        {
            capacityTimer += Time.deltaTime;
            if (capacityTimer >= capacityCooldown)
            {
                currentCapacity--;
                capacityTimer = 0f;
                Debug.Log("capacity 1 감소. 현재 capacity : " + currentCapacity);
            }
        }
    }

    public void Upgrade()
    {
        currentCapacity = 0; // 스테이지 클리어나 업그레이드 시 초기화
    }

}
