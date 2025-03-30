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
            Debug.Log("ó����");
            if (currentCapacity < machine.capacity)
            {
                currentCapacity++;
                Debug.Log("���� �ö�");
                gameManager.AddScore();
                currentCapacity--;  // ? ó�� �� ��� ����
            }
            else
            {
                // �����÷ο�
                other.transform.position = overflowZone.position;
                gameManager.OverflowPenalty();
            }

            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        currentCapacity = 0; // �������� Ŭ��� ���� ���׷��̵� �� �ʱ�ȭ ����
    }
}
