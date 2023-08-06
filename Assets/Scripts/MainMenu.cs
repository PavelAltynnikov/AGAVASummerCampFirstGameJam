using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("Room2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
