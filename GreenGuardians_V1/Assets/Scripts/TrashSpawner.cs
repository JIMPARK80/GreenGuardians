using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab;
    public MachineController machine;
    public float spawnInterval = 2f;
    public GameManager gameManager;

    private void Start()
    {
        InvokeRepeating("SpawnTrash", 1f, spawnInterval);
    }

    void SpawnTrash()
    {
        GameObject newTrash = Instantiate(trashPrefab, transform.position, Quaternion.identity);
        newTrash.GetComponent<Trash>().machine = machine;
        newTrash.GetComponent<Trash>().gameManager = gameManager;  // ? 반드시 추가
    }
}
