using UnityEngine; // Unity Engine Related Namespace

    public class MachineController : MonoBehaviour // Machine Controller Class
{
    public float speed = 1.0f;  // speed
    
    public void Upgrade()
    {
        speed += 0.5f;  // when quiz is correct, only speed increases
        Debug.Log($"Machine Speed Upgraded: {speed:F1}");
    }

    public void ResetMachine()
    {
        speed = 1.0f;  // when reset, only speed is reset
    }
}
