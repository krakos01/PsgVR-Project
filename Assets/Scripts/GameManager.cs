using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemiesDestroyed = 0;
    private int score;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); return; }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddPoints(int points)
    {
        score += points;
    }

    public void EndGame()
    {
        // Save score to PlayerPrefs
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();

        // Load the EndMenu scene
        SceneManager.LoadScene("EndMenu");
    }



    // Destroy player object when hp <= 0
    public void PlayerDied(GameObject player)
    {
        Destroy(player);
        Debug.Log("Game Over");
    }

    public void EnemyDies(GameObject enemy)
    {
        Destroy(enemy);
        enemiesDestroyed++;
    }
}
