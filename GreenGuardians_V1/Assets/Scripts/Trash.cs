using UnityEngine; // Unity Engine Related Namespace

public class Trash : MonoBehaviour // Trash Class
{
    public MachineController machine; // Machine Controller Variable
    private bool isSorting = false; // Sorting status variable
    private Vector2 moveDir = Vector2.right; // Movement direction variable
    private SpriteRenderer sr; // Sprite renderer variable
    public GameManager gameManager; // Game Manager Variable

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>(); // Get sprite renderer
        moveDir = Vector2.right; // Set default movement direction
    }

    void Update()
    {
        transform.Translate(moveDir * machine.speed * Time.deltaTime); // Move trash

        if (isSorting && transform.position.y < -2f) // When completely sorted (when it goes below the screen)
        {
            Destroy(gameObject);
            Debug.Log("sorting");
        }

        if (!isSorting && transform.position.x > 5f) // Overflow case
        {
            gameManager.OverflowPenalty(); // Apply overflow penalty
            Destroy(gameObject); // Destroy trash object
            Debug.Log("overflow"); // Log overflow
        }
    }

    public void StartSorting() // Start sorting
    {
        isSorting = true; // Set sorting status variable
        moveDir = Vector2.down; // Set movement direction variable
        sr.color = Color.green; // Change sprite renderer color
        Debug.Log("SorterZone: Start sorting + green"); // Log sorting
    }

    public void StartOverflow() // Start overflow
    {
        isSorting = false; // Set sorting status variable
        moveDir = Vector2.right; // Set movement direction variable
        sr.color = Color.red; // Change sprite renderer color
        Debug.Log("Overflow: Start overflow + red"); // Log overflow
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // capacity related check removed
        // keep only necessary logic
    }
}
