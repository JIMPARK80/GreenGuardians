using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f; // 게임 시작할 때 시간 스케일 초기화 / Initialize time scale when game starts
        SceneManager.LoadScene("MainScene"); // 게임 씬 로드 / Load game scene
    }

    public void OpenOptions()
    {
        Debug.Log("Options Clicked"); // 나중에 옵션 패널에 연결할 것 / Later you will connect this to Options Panel
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Clicked (won't work in editor)"); // 편집기에서는 작동하지 않음 / Won't work in editor
    }

}
