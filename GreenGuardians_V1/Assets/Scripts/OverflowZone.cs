using UnityEngine;

public class OverflowZone : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            gameManager.OverflowPenalty();
            Destroy(other.gameObject);
        }
    }
}
