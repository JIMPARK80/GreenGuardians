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
        moveDir = Vector2.right; // 초기에는 오른쪽으로 이동
    }

    void Update()
    {
        transform.Translate(moveDir * machine.speed * Time.deltaTime);

        // 아래로 충분히 떨어지면 제거
        if (transform.position.y < -5f)
            Destroy(gameObject);
    }

    public void StartSorting()
    {
        isSorting = true;
        moveDir = Vector2.down;   // ?? 방향을 아래로 전환
        sr.color = Color.green;     // ?? 색상 즉시 변경
        Debug.Log("SorterZone 진입 → 방향 아래로 변경 + 색상 Green");
    }

    public void StartOverflow()
    {
        moveDir = Vector2.right;  // 오버플로우는 오른쪽으로 흘러가게
        sr.color = Color.red;      // 시각적으로 표시
        Debug.Log("SorterZone 진입 → 방향 오른쪽 통과 + 색상 red");
    }

}
