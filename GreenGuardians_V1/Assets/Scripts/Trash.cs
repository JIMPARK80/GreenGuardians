using UnityEngine;

public class Trash : MonoBehaviour
{
    public MachineController machine;
    private bool isSorting = false;
    private Vector2 moveDir;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        moveDir = Vector2.right; // �ʱ⿡�� ���������� �̵�
    }

    void Update()
    {
        transform.Translate(moveDir * machine.speed * Time.deltaTime);

        // �Ʒ��� ����� �������� ����
        if (transform.position.y < -5f)
            Destroy(gameObject);
    }

    public void StartSorting()
    {
        isSorting = true;
        moveDir = Vector2.down;   // ?? ������ �Ʒ��� ��ȯ
        sr.color = Color.green;     // ?? ���� ��� ����
        Debug.Log("SorterZone ���� �� ���� �Ʒ��� ���� + ���� Green");
    }

    public void StartOverflow()
    {
        moveDir = Vector2.right;  // �����÷ο�� ���������� �귯����
        sr.color = Color.red;      // �ð������� ǥ��
        Debug.Log("SorterZone ���� �� ���� ������ ��� + ���� red");
    }

}
