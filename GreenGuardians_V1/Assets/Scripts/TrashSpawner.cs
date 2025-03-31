using UnityEngine; // Unity 엔진 관련 네임스페이스 / Unity Engine Related Namespace

public class TrashSpawner : MonoBehaviour // 쓰레기 스폰러 클래스 / Trash Spawner Class
{
    public GameObject trashPrefab; // 쓰레기 프리펩 변수 / Trash Prefab Variable
    public MachineController machine; // 기계 컨트롤러 변수 / Machine Controller Variable
    public float spawnInterval = 2f; // 스폰 간격 변수 / Spawn interval variable
    public GameManager gameManager; // 게임 매니저 변수 / Game Manager Variable

    private void Start() // 시작 시 쓰레기 스폰 / Start spawning trash
    {
        InvokeRepeating("SpawnTrash", 1f, spawnInterval); // 1초 후에 쓰레기 스폰 / Spawn trash after 1 second
    }

    void SpawnTrash() // 쓰레기 스폰 / Spawn trash
    {
        GameObject newTrash = Instantiate(trashPrefab, transform.position, Quaternion.identity); // 쓰레기 인스턴스화 / Instantiate trash
        newTrash.GetComponent<Trash>().machine = machine; // 기계 컨트롤러 설정 / Set machine controller
        newTrash.GetComponent<Trash>().gameManager = gameManager;  // 게임 매니저 설정 / Set game manager
    }
}
