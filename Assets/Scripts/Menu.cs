using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        GameObject scoreTextObject = GameObject.Find("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            scoreText.text = "SCORE: " + finalScore.ToString();
        }
    }

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
