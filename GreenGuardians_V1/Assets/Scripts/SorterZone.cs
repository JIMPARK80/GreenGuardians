using UnityEngine; // Unity Engine Related Namespace

public class SorterZone : MonoBehaviour // Sorter Zone Class
{
    
    public MachineController machine; // Machine Controller Variable
    public GameManager gameManager; // Game Manager Variable

    [Header("Stage level settings")] // Stage level settings related header
    public float sortCooldown = 2f; // Sort cooldown time
    private float lastSortTime = 1f; // Last sort time

    private void OnTriggerEnter2D(Collider2D other) // Function called when collision occurs
    {
        if (!other.CompareTag("Trash")) return; // Return if the collided object is not trash

        Trash trash = other.GetComponent<Trash>(); // Get trash component

        float sortingTime = 1f / machine.speed;  // Calculate sorting time based on processing speed

        // Check cooldown instead of capacity
        if (Time.time - lastSortTime >= sortCooldown)
        {
            lastSortTime = Time.time; // Update last sort time
            trash.StartSorting(); // Start sorting trash
            gameManager.AddScore(); // Increase score
        }
        else
        {
            // If machine capacity is less than 0 or last sort time is less than sort cooldown time
            trash.StartOverflow(); // Start overflow
        }
    }
}
