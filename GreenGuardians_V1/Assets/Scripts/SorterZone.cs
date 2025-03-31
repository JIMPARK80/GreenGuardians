using UnityEngine;

public class SorterZone : MonoBehaviour
{
    public MachineController machine;
    public GameManager gameManager;
    public Transform overflowZone;

    private int currentCapacity = 0;
    private float capacityCooldown = 0.5f; // ������ �ϳ� ó�� �� 0.5�� �ڿ� capacity -1
    private float capacityTimer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            Debug.Log("ó����");

            if (currentCapacity < machine.capacity)
            {
                currentCapacity++;
                Debug.Log("���� �ö�");
                gameManager.AddScore();
                other.GetComponent<Trash>().StartSorting();
                // Destroy() ����
            }
            else
            {
                // �����÷ο�
                Debug.Log("overflow +1");
                gameManager.OverflowPenalty();
                other.GetComponent<Trash>().StartOverflow(); // ���������� �̵�
                // Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        // capacity �ڿ� ���� (������ �ð��� ������ ������� ����)
        if (currentCapacity > 0)
        {
            capacityTimer += Time.deltaTime;
            if (capacityTimer >= capacityCooldown)
            {
                currentCapacity--;
                capacityTimer = 0f;
                Debug.Log("capacity 1 ����. ���� capacity : " + currentCapacity);
            }
        }
    }

    public void Upgrade()
    {
        currentCapacity = 0; // �������� Ŭ��� ���׷��̵� �� �ʱ�ȭ
    }

}
