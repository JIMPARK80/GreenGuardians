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
        moveDir = Vector2.right; // 기본 오른쪽 이동
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
            gameManager.OverflowPenalty(); // ? Overflow 카운트 증가
            Destroy(gameObject);
            Debug.Log("overflow");
        }
    }

    public void StartSorting()
    {
        isSorting = true;
        moveDir = Vector2.down;
        sr.color = Color.green;
        Debug.Log("SorterZone 진입 → 아래로 이동 + 색상 green");
    }

    public void StartOverflow()
    {
        isSorting = false;
        moveDir = Vector2.right;
        sr.color = Color.red;
        Debug.Log("Overflow 진입 → 계속이동 + 색상 red");
    }
}
