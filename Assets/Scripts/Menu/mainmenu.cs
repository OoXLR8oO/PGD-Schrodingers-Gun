using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GameHelp()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
