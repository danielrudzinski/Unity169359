using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadMenu", 3f);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}