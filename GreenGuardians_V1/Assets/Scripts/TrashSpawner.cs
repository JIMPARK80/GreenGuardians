using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab;
    public MachineController machine; // 추가

    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnTrash", 1f, spawnInterval);
    }

    void SpawnTrash()
    {
        GameObject newTrash = Instantiate(trashPrefab, transform.position, Quaternion.identity);
        newTrash.GetComponent<Trash>().machine = machine; // ? 반드시 연결
    }
}
