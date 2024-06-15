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

    private IEnumerator LoadSceneAfterTime(string nameScene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nameScene);
    }

    public void PlayGame()
    {
        StartCoroutine(LoadSceneAfterTime("Game"));
    }

    public void ExitGame()
    {
        Debug.Log("QUIT");
        StartCoroutine(ExitGameAfterTime());
    }

    private IEnumerator ExitGameAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    public void OpenScoreboard()
    {
        StartCoroutine(LoadSceneAfterTime("Scoreboard"));
    }

    public void OpenMenu()
    {
        StartCoroutine(LoadSceneAfterTime("StartMenu"));
    }
}
