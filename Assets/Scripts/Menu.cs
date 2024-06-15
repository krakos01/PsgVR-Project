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

        StartCoroutine(WaitAMoment());
    }

    public IEnumerator WaitAMoment()
    {
        yield return new WaitForSeconds(1f);
    }

    public void PlayGame()
    {
        WaitAMoment();
        SceneManager.LoadScene("GAME");
    }

    public void ExitGame()
    {
        WaitAMoment();
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void OpenScoreboard()
    {
        WaitAMoment();
        SceneManager.LoadScene("Scoreboard");
    }

    public void OpenMenu()
    {
        WaitAMoment();
        SceneManager.LoadScene("StartMenu");
    }
}
