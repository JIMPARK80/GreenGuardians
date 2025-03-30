using UnityEngine;

public class MachineController : MonoBehaviour
{
    public float speed = 1.0f;
    public int capacity = 3;

    public void Upgrade()
    {
        speed += 0.5f;
        capacity += 1;
    }
}
