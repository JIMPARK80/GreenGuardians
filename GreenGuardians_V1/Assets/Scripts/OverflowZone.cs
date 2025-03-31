using UnityEngine;

public class OverflowZone : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            Debug.Log("overflow delete");
            gameManager.OverflowPenalty();
            Destroy(other.gameObject);
        }
    }
}
