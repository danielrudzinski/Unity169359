using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("The_Viking_Village");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}