using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace

public class Trash : MonoBehaviour // 쓰레기 클래스 / Trash Class
{
    public MachineController machine; // 기계 컨트롤러 변수 / Machine Controller Variable
    private bool isSorting = false; // 정렬 여부 변수 / Sorting status variable
    private Vector2 moveDir = Vector2.right; // 이동 방향 변수 / Movement direction variable
    private SpriteRenderer sr; // 스프라이트 렌더러 변수 / Sprite renderer variable
    public GameManager gameManager; // 게임 매니저 변수 / Game Manager Variable

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 가져오기 / Get sprite renderer
        moveDir = Vector2.right; // 기본 이동 방향 설정 / Set default movement direction
    }

    void Update()
    {
        transform.Translate(moveDir * machine.speed * Time.deltaTime); // 쓰레기 이동 / Move trash

        if (isSorting && transform.position.y < -2f) // 완전히 정렬된 경우 (화면 아래로 나간 경우)
        {
            Destroy(gameObject);
            Debug.Log("sorting");
        }

        if (!isSorting && transform.position.x > 5f) // 오버플로우 경우 / Overflow case
        {
            gameManager.OverflowPenalty(); // 오버플로우 패널티 적용 / Apply overflow penalty
            Destroy(gameObject); // 쓰레기 객체 삭제 / Destroy trash object
            Debug.Log("overflow"); // 오버플로우 로그 출력 / Log overflow
        }
    }

    public void StartSorting() // 정렬 시작 / Start sorting
    {
        isSorting = true; // 정렬 여부 변수 설정 / Set sorting status variable
        moveDir = Vector2.down; // 이동 방향 변수 설정 / Set movement direction variable
        sr.color = Color.green; // 스프라이트 렌더러 색상 변경 / Change sprite renderer color
        Debug.Log("SorterZone: Start sorting + green"); // 정렬 로그 출력 / Log sorting
    }

    public void StartOverflow() // 오버플로우 시작 / Start overflow
    {
        isSorting = false; // 정렬 여부 변수 설정 / Set sorting status variable
        moveDir = Vector2.right; // 이동 방향 변수 설정 / Set movement direction variable
        sr.color = Color.red; // 스프라이트 렌더러 색상 변경 / Change sprite renderer color
        Debug.Log("Overflow: Start overflow + red"); // 오버플로우 로그 출력 / Log overflow
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // capacity 관련 체크 제거
        // 필요한 로직만 남기기
    }
}
