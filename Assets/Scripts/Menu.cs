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
}
