using UnityEngine;

public class Trash : MonoBehaviour
{
    public MachineController machine;
    private bool isSorting = false;
    private Vector2 moveDir = Vector2.right;
    private SpriteRenderer sr;
    public GameManager gameManager;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        moveDir = Vector2.right; // �⺻ ������ �̵�
    }

    void Update()
    {
        transform.Translate(moveDir * machine.speed * Time.deltaTime);

        // ? if fully sorted (goes below screen)
        if (isSorting && transform.position.y < -2f)
        {
            machine.capacity++;   // ? recover capacity here
            Destroy(gameObject);
            Debug.Log("sorting");
        }

        // overflow case
        if (!isSorting && transform.position.x > 5f)
        {
            gameManager.OverflowPenalty(); // ? Overflow ī��Ʈ ����
            Destroy(gameObject);
            Debug.Log("overflow");
        }
    }

    public void StartSorting()
    {
        isSorting = true;
        moveDir = Vector2.down;
        sr.color = Color.green;
        Debug.Log("SorterZone ���� �� �Ʒ��� �̵� + ���� green");
    }

    public void StartOverflow()
    {
        isSorting = false;
        moveDir = Vector2.right;
        sr.color = Color.red;
        Debug.Log("Overflow ���� �� ����̵� + ���� red");
    }
}
