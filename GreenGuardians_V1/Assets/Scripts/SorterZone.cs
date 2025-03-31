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

        // ���� ó�� ������ ���
        if (machine.capacity > 0 && Time.time - lastSortTime >= sortCooldown)
        {
            lastSortTime = Time.time;
            machine.capacity--;
            trash.StartSorting(); // �ʷϻ� ����
            gameManager.AddScore();
        }
        else
        {
            // ó�� �Ұ� ���¿����� �ٷ� overflow �ĺ��� ���� �Ӱ� ����
            trash.StartOverflow(); // ������ ���游 �ϰ� ��� (���� overflow�� �ƴ�)
        }
    }
}
