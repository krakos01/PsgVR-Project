using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GAME");
    }

    public void ExitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void OpenScoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
