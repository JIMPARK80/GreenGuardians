using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f; // Initialize time scale when game starts
        SceneManager.LoadScene("MainScene"); // Load game scene
    }

    public void OpenOptions()
    {
        Debug.Log("Options Clicked"); // Later you will connect this to Options Panel
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Clicked (won't work in editor)"); // Won't work in editor
    }

}
