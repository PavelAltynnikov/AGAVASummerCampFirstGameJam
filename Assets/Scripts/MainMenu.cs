using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("Room1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
