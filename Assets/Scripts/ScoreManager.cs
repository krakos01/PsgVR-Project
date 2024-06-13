using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static ScoreManager Instance;

    private int score;


    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); return; }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
       //  UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score;
    }

    public int GetScore() { return score; }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
