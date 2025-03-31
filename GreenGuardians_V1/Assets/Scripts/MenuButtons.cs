using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f; // << �ݵ�� �߰�
        SceneManager.LoadScene("MainScene"); // Change to your real game scene name
    }

    public void OpenOptions()
    {
        Debug.Log("Options Clicked"); // Later you will connect this to Options Panel
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Clicked (won't work in editor)");
    }

    /*
    public void BackToTitle()
    {
        Time.timeScale = 1f;  // �߿�!! ���� Ǯ��
        SceneManager.LoadScene("GameStart");
    }
    */

}
