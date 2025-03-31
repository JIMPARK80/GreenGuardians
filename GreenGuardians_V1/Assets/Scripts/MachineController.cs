using UnityEngine;

public class MachineController : MonoBehaviour
{
    public float speed = 1.0f;
    public float capacity = 1.0f;

    public void Upgrade()
    {
        speed += 0.5f;
        capacity += 0.5f;
    }
}
