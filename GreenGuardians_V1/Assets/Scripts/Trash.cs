using UnityEngine;

public class Trash : MonoBehaviour
{
    public MachineController machine;

    void Update()
    {
        if (machine != null)
            transform.Translate(Vector2.right * machine.speed * Time.deltaTime);
    }

}
